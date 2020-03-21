using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDClinic.Models;
using Microsoft.AspNetCore.Mvc;
using SDClinic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SDClinic.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DoctorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Doctor dr = _context.Doctors.Where(s => s.username == username).First();
            ViewBag.doctor = dr;
            ViewBag.id = dr.Id;
            return View();
        }
        public IActionResult UpdateDatePage(int drId, int dateId)
        {
            if (drId == null || dateId == null)
                return NotFound();
            Date date = _context.Dates.Where(s => s.Id == dateId).First();
            List<Patient> patients = _context.Patients.ToList();
            ViewBag.patients = patients;
            ViewBag.date = date;
            ViewBag.drId = drId;
            return View();
        }
        public async Task<IActionResult> UpdateDate(int dateId, int drId, int ptId, DateTime dt)
        {

            Date d = _context.Dates.Where(s => s.Id == dateId).First();
            Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            Patient pt = _context.Patients.Where(s => s.Id == ptId).First();
            d.Patient = pt;
            d.PatientId = ptId;
            d.Doctor = dr;
            d.DoctorId = drId;
            d.date_dateTime = dt;
            try
            {
                _context.Dates.Update(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates", new { id = drId });
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageDates", new { id = drId });
        }
        public async Task<IActionResult> CreateDate(int drId, int ptId, DateTime date)
        {
            Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            Patient pt = _context.Patients.Where(s => s.Id == ptId).First();
            Date d = new Date();
            d.Patient = pt;
            d.PatientId = ptId;
            d.Doctor = dr;
            d.DoctorId = drId;
            d.date_dateTime = date;
            try
            {

                _context.Dates.Add(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates", new { id = drId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageDates", new { id = drId });
        }
        public async Task<IActionResult> DeleteDate(int drId, int dateId)
        {
            Date d = _context.Dates.Where(s => s.Id == dateId).First();
            try
            {

                _context.Dates.Remove(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDates", new { id = drId });

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
            return RedirectToAction("ManageDates", new { id = drId });
        }
        public async Task<IActionResult> DeleteConsultation(int drId, int conId)
        {
            Consultation d = _context.Consultations.Where(s => s.Id == conId).First();
            try
            {

                _context.Consultations.Remove(d);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation", new { id = drId });

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
            return RedirectToAction("ManageConsultation", new { id = drId });
        }
        public IActionResult ManageDates(int? id)
        {
            List<Date> dates = _context.Dates.Where(s => s.DoctorId == id).ToList();
            Doctor dr = _context.Doctors.Where(s => s.Id == id).First();
            List<Patient> patients = _context.Patients.ToList();
            ViewBag.dates = dates;
            ViewBag.dr = dr;
            ViewBag.patients = patients;
            return View();
        }
        public IActionResult ViewPatients(int? id)
        {
            List<Patient> pat = _context.Patients.ToList();
            Doctor dr = _context.Doctors.Where(s => s.Id == id).First();
            ViewBag.doctor = dr;
            ViewBag.patients = pat;
            return View();
        }
        public async Task<IActionResult> UpdateConsultation(int drId, int ptId, int conId, String Symptoms, String Diagnoses, String Temp, String BloodPressure, String Treatment)
        {
            Consultation c = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).First();
            Doctor dr = _context.Doctors.Where(s => s.Id == c.DoctorId).First();
            Patient pt = _context.Patients.Where(s => s.Id == c.PatientId).First();
            c.Symptoms = Symptoms;
            c.Diagnoses = Diagnoses;
            c.Temp = Temp;
            c.BloodPressure = BloodPressure;
            c.Treatment = Treatment;
            try
            {
                _context.Consultations.Update(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation", new { id = drId });
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageConsultation", new { id = drId });
        }
        public IActionResult CreateConsultationPage(int id)
        {

            List<Patient> patients = _context.Patients.ToList();
            if (patients == null)
                return NotFound();
            ViewBag.patients = patients;
            ViewBag.drId = id;

            return View();
        }
        public IActionResult UpdateConsultationPage(int drId, int conId) {
            Consultation c = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).First();
            ViewBag.cons = c;
            ViewBag.drId = drId;
            return View();
        }
        public async Task<IActionResult> CreateConsultation(Consultation c) {
            int drId = c.DoctorId;
            if (drId == null || c == null)
            {
                return NotFound();
            }
            Patient pat = _context.Patients.Where(s => s.Id == c.PatientId).First();
            Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            //c.Patient = pat;
            //c.Doctor = dr;
            try
            {

                _context.Consultations.Add(c);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageConsultation", new { id = drId });

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("ManageConsultation", new { id = drId });
        }
        public IActionResult ViewConsultation(int drId, int conId)
        {
            if (drId == null || conId == null)
                return NotFound();
            Consultation cons = _context.Consultations.Where(s => s.Id == conId).Include(s => s.Patient).First();
            ViewBag.cons = cons;
            ViewBag.drId = drId;
            return View();
        }
        public IActionResult ManageConsultation(int id)
        {
            Doctor dr = _context.Doctors.Where(s => s.Id == id).First();
            List<Consultation> c = _context.Consultations.Where(s => s.DoctorId == id).Include(s => s.Patient).ToList();
            ViewBag.consultations = c;
            ViewBag.dr = dr;

            return View();
        }
        public async Task<IActionResult> AddMessage(int drid, Messages msg)
        {
            Doctor dr = _context.Doctors.Where(s => s.Id == drid).First();
            //msg.DateMsg = DateTime.Now;
            msg.Name = dr.fname + " " + dr.mname + " " + dr.lname;
           
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Messages.Add(msg);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("SendMessage", new { id = drid });
                }
            }
            catch (DbUpdateException)
            {
                
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("SendMessage", new { id = drid });
        }
        public IActionResult ReminderPage() {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Doctor dr = _context.Doctors.Where(s => s.username == username).First();
            int id = dr.Id;
            List<Reminder_Doctor> rds = _context.Reminder_Doctors.Where(s => s.DoctorId == id).ToList();
            ViewBag.rds = rds;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> ReminderAdd(int drid, Reminder_Doctor rd)
        {
            ViewBag.id = drid;
     
            try
            {

                _context.Reminder_Doctors.Add(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = drid });

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
 

            return RedirectToAction("ReminderPage",new { id=drid});
    }
        public async Task<IActionResult> DeleteReminder(int drId, int remId)
        {
            Reminder_Doctor rd = _context.Reminder_Doctors.Where(s => s.Id == remId).First();
            try
            {

                _context.Reminder_Doctors.Remove(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = drId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("ReminderPage", new { id = drId });
        }
        public IActionResult SendMessage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Doctor dr = _context.Doctors.Where(s => s.username == username).First();
            int id = dr.Id;
            ViewBag.id = id;
            
            String name = dr.fname + " " + dr.mname + " " + dr.lname;
            List<Messages> msgs = _context.Messages.Where(s => s.Name.Equals(name)).ToList();
            ViewBag.msgs = msgs;
            return View();
        }
        public IActionResult ViewProfile()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Doctor dr = _context.Doctors.Where(s => s.username == username).First();
            int id = dr.Id;
            ViewBag.id = id;
            ViewBag.dr = dr;
            return View();
        }
    }
}