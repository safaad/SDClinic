using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDClinic.Data;
using SDClinic.Models;

namespace SDClinic.Controllers
{
   
    [Authorize(Roles = "Assistant")]
    public class AssistantController : Controller
    {
      
        private readonly IHostingEnvironment _appEnvironment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AssistantController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            Assistant assist = _context.Assistants.Where(s => s.username == username).First();
            ViewBag.assistant = assist;
            ViewBag.id = assist.Id;
            return View();
        }
        public async Task<IActionResult> ManagePatients(int id)
        {
            var usersOfRole = await _userManager.GetUsersInRoleAsync("Patient");
            List<Patient> patients = _context.Patients.ToList();
            List<InsuranceCompany> ins= _context.Insurance_Companies.ToList();
            ViewBag.patients = patients;
            ViewBag.id = id;
            ViewBag.ins = ins;
            ViewBag.users = usersOfRole;
            return View();
        }
        public async Task<IActionResult> CreatePatient(int asisId,PatientModel patient,String Email) {
            if (patient.pic != null) {
                var fileName = Path.Combine(_appEnvironment.WebRootPath, Path.GetFileName(patient.pic.FileName));
                patient.pic.CopyTo(new FileStream(fileName, FileMode.Create));
                patient.Picture = "/" + Path.GetFileName(patient.pic.FileName);

            }
            String Password = "Pass.1234";
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Email, Email = Email };
                var userOld = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _userManager.CreateAsync(user, Password);
                if (result.Succeeded)
                {
                    Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(user, "Patient");
                    newUserRole.Wait();

                    Patient pt = new Patient();
                    pt.username = user.Id;
                    pt.Address = patient.Address;
                    pt.fname = patient.fname;
                    pt.mname = patient.mname;
                    pt.lname = patient.lname;
                    pt.pat_insurance_company_name = patient.pat_insurance_company_name;
                    pt.Gender = patient.Gender;
                    pt.Picture = patient.Picture;
                    pt.BloodType = patient.BloodType;
                    pt.Birthday = patient.Birthday;
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    try
                    {

                        _context.Patients.Add(pt);
                        await _context.SaveChangesAsync();
                        await _signInManager.SignInAsync(userOld, isPersistent: false);
                        return RedirectToAction("ManagePatients", new { id = asisId });

                    }
                    catch (DbUpdateException)
                    {
                        //Log the error (uncomment ex variable name and write a log.
                        ModelState.AddModelError("", "Unable to save changes. " +
                            "Try again, and if the problem persists " +
                            "see your system administrator.");
                    }
                }
            }
            return RedirectToAction("ManagePatients", new { id = asisId });

        }
        public async Task<IActionResult> DeletePatient(int asisId, int ptId)
        {
            Patient p = _context.Patients.Where(s => s.Id == ptId).First();
            var user = await _userManager.FindByIdAsync(p.username);
            try
            {

                _context.Patients.Remove(p);
                await _userManager.DeleteAsync(user);
               
                await _context.SaveChangesAsync();
                //if (!p.Picture.Equals("/images/unkown.jpg")) {
                //    System.IO.File.Delete(p.Picture);
                //}
                return RedirectToAction("ManagePatients", new { id = asisId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
        
            return RedirectToAction("ManagePatients", new { id = asisId });
        }
        public IActionResult ViewPatient(int asisId, int ptId)
        {
            Patient p = _context.Patients.Where(s => s.Id == ptId).First();
            ViewBag.id = asisId;
            ViewBag.pt = p;
            return View();
        }
        public IActionResult UpdatePatientPage(int asisId,int ptId)
        {
            Patient p = _context.Patients.Where(s => s.Id == ptId).First();
            List<InsuranceCompany> ins = _context.Insurance_Companies.ToList();
            ViewBag.ins = ins;
             ViewBag.id = asisId;
            ViewBag.pt = p;
            return View();
        }
        public async Task<IActionResult> UpdatePatient(int asisId,int ptId,String fname,String mname,String lname,String Gender,DateTime Birthday,String Address,String BloodType,String pat_insurance_company_name)
        {
            Patient p = _context.Patients.Where(s => s.Id == ptId).First();
            p.fname = fname;
            p.lname = lname;
            p.mname = mname;
            p.Gender = Gender;
            p.Address = Address;
            p.Birthday = Birthday;
            p.BloodType = BloodType;
            p.pat_insurance_company_name = pat_insurance_company_name;
            try
            {
                _context.Patients.Update(p);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManagePatients", new { id = asisId });
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManagePatients", new { id = asisId });
        }
        public IActionResult ManageDates()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant asis = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
            List<Date> dates = _context.Dates.Where(s => s.DoctorId == asis.DoctorId).ToList();
            
            Doctor dr = asis.Doctor;
            List<Patient> patients = _context.Patients.ToList();
            ViewBag.dates = dates;
            ViewBag.dr = dr;
            ViewBag.id = asis.Id;
            ViewBag.patients = patients;
            return View();
        }
        public IActionResult UpdateDatePage(int dateId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant asis = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
            Doctor dr = asis.Doctor;
            Date date = _context.Dates.Where(s => s.Id == dateId).Include(s=>s.Patient).First();
            List<Patient> patients = _context.Patients.ToList();
            ViewBag.patients = patients;
            ViewBag.date = date;
            ViewBag.drId = dr.Id;
            ViewBag.asisId = asis.Id;
            return View();
        }
        public async Task<IActionResult> UpdateDate(int dateId,int ptId,DateTime dt)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant asis = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();

            Doctor dr = asis.Doctor;
            Date d = _context.Dates.Where(s => s.Id == dateId).First();

            //Patient pt = _context.Patients.Where(s => s.Id == ptId).First();
            //d.Patient = pt;
            d.PatientId = ptId;
            //d.Doctor = dr;
            d.DoctorId = dr.Id;
            d.date_dateTime = dt;
            try
            {
                _context.Dates.Update(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates");
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageDates");
        }
        public async Task<IActionResult> CreateDate(Date d)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Assistant asis = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
            
            
            Doctor dr = asis.Doctor;
       

            d.DoctorId = asis.DoctorId;
         
            try
            {

                _context.Dates.Add(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates", new { id = asis.Id });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageDates", new { id = asis.Id });
        }
        public async Task<IActionResult> DeleteDate(int asisId, int dateId)
        {
            Date d = _context.Dates.Where(s => s.Id == dateId).First();
            try
            {

                _context.Dates.Remove(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates", new { id = asisId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            _context.Dates.Add(d);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageDates", new { id = asisId });
        }
        public IActionResult SendMessage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Assistant assist = _context.Assistants.Where(s => s.username == username).First();
            int id = assist.Id;
            ViewBag.id = id;
            Assistant asis = _context.Assistants.Where(s => s.Id == id).First();
            String name = asis.FName + " " + asis.MName + " " + asis.LName;
            List<Messages> msgs = _context.Messages.Where(s => s.Name.Equals(name)).ToList();
            ViewBag.msgs = msgs;
            return View();
        }
        public async Task<IActionResult> AddMessage(int asisid, Messages msg)
        {
            Assistant asis = _context.Assistants.Where(s => s.Id == asisid).First();
            msg.DateMsg = DateTime.Now;
            msg.Name = asis.FName + " " + asis.MName + " " + asis.LName;

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Messages.Add(msg);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("SendMessage", new { id = asisid });
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("SendMessage", new { id = asisid });
        }
        public IActionResult ReminderPage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Assistant assist = _context.Assistants.Where(s => s.username == username).First();
            int id = assist.Id;
            List<Reminder_Assistant> rds = _context.Reminder_Assistants.Where(s => s.AssistantId == id).ToList();
            ViewBag.rds = rds;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> ReminderAdd(int asisid, Reminder_Assistant rd)
        {
            ViewBag.id = asisid;

            try
            {

                _context.Reminder_Assistants.Add(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = asisid });

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ReminderPage", new { id = asisid });
        }
        public async Task<IActionResult> DeleteReminder(int asisId, int remId)
        {
            Reminder_Assistant rd = _context.Reminder_Assistants.Where(s => s.Id == remId).First();
            try
            {

                _context.Reminder_Assistants.Remove(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = asisId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ReminderPage", new { id = asisId });
        }
        public IActionResult ViewProfile() {

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            Assistant assist = _context.Assistants.Where(s => s.username == username).Include(s=>s.Doctor).First();
            int id = assist.Id;
            
            ViewBag.id = id;
            ViewBag.asis = assist;
            return View();
        }
        public async Task<IActionResult> UpdateConsultation(Consultation c)
        {
            Console.WriteLine("" + c.Id + " " + c.PatientId + " " + c.DoctorId + " " + c.Diagnoses + " " + c.DateCons + " " + c.Treatment + " " + c.BloodPressure + " " + c.Temp);
            //Consultation c = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).First();
            //Doctor dr = _context.Doctors.Where(s => s.Id == c.DoctorId).First();
            //Patient pt = _context.Patients.Where(s => s.Id == c.PatientId).First();
            //c.Symptoms = Symptoms;
            //c.Diagnoses = Diagnoses;
            //c.Temp = Temp;
            //c.BloodPressure = BloodPressure;
            //c.Treatment = Treatment;
            try
            {
                _context.Consultations.Update(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation");
            }
            catch (DbUpdateException)
            {
        
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageConsultation");
        }
        public IActionResult CreateConsultationPage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant assist = _context.Assistants.Where(s => s.username == username).Include(s=>s.Doctor).First();
            List<Patient> patients = _context.Patients.ToList();
            if (patients == null)
                return NotFound();
            ViewBag.patients = patients;
            ViewBag.drId = assist.Doctor.Id;
            ViewBag.asisId = assist.Id;
            return View();
        }
        public IActionResult UpdateConsultationPage(int conId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant assist = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
            List<Patient> patients = _context.Patients.ToList();
            
            Consultation c = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).First();
            ViewBag.cons = c;
            ViewBag.drId =assist.Doctor.Id;
            ViewBag.asis = assist;
            return View();
        }
        public async Task<IActionResult> CreateConsultation(Consultation c)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("CreateConsultationPage");
            //}
            int drId = c.DoctorId;
          
            //Patient pat = _context.Patients.Where(s => s.Id == c.PatientId).First();
            //Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            //c.Patient = pat;
            //c.Doctor = dr;
            try
            {

                _context.Consultations.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation");

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("ManageConsultation");
        }
        public IActionResult ViewConsultation(int conId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant assist = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
           
            Consultation cons = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).Include(s=>s.Doctor).First();
            ViewBag.cons = cons;
            ViewBag.drId = assist.DoctorId;
            ViewBag.asis = assist;
            return View();
        }
        public IActionResult ManageConsultation()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Assistant assist = _context.Assistants.Where(s => s.username == username).Include(s => s.Doctor).First();
            List<Consultation> c = _context.Consultations.Where(s => s.DoctorId == assist.DoctorId).Include(s => s.Patient).ToList();
            ViewBag.consultations = c;
            ViewBag.dr = assist.Doctor;
            ViewBag.asis = assist;
            return View();
        }
        public async Task<IActionResult> DeleteConsultation(int conId)
        {
            Consultation d = _context.Consultations.Where(s => s.Id == conId).First();
            try
            {

                _context.Consultations.Remove(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            _context.Consultations.Add(d);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageConsultation");
        }
    }
}