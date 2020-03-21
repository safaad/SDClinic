using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDClinic.Data;
using SDClinic.Models;

namespace SDClinic.Controllers
{
    [Authorize(Roles = "Patient")]
    public class PatientController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public PatientController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Patient pt = _context.Patients.Where(s => s.username == username).First();
            ViewBag.pt = pt;
            ViewBag.id = pt.Id;
            return View();
        }
        public IActionResult ViewDates(int id)
        {
            List<Date> dates = _context.Dates.Where(s => s.PatientId == id).Include(s => s.Doctor).ToList();
            ViewBag.dates = dates;
            ViewBag.id = id;
            return View();
        }
        public IActionResult ViewTreatment(int id)
        {
            List<Consultation> cons = _context.Consultations.Where(s => s.PatientId == id).Include(s => s.Doctor).ToList();
            ViewBag.cons = cons;
            ViewBag.id = id;
            return View();
        }
        public IActionResult ViewConsultation(int ptId,int consId)
        {
            Consultation con = _context.Consultations.Where(s => s.Id == consId).Include(s => s.Doctor).First();
            Patient pt = _context.Patients.Where(s => s.Id == ptId).First();
            ViewBag.con = con;
            ViewBag.pt = pt;
            return View();
        }
        public IActionResult SearchDoctor(int ptId,String name,String speciality)
        {
            List<Doctor> drs=null;
            if (name==null && speciality=="all") {
                drs = _context.Doctors.ToList();
            }
            if(name==null && speciality != "all")
            {
                drs = _context.Doctors.Where(s => s.Speciality == speciality).ToList();
            }
            if (name != null && speciality == "all")
            {
                drs = _context.Doctors.Where(s => ("" + s.fname + " " + s.mname + " " + s.lname).Contains(name)).ToList();

            }
            if (name != null && speciality != "all")
            {
                drs = _context.Doctors.Where(s => ("" + s.fname + " " + s.mname + " " + s.lname).Contains(name)).Where(s=>s.Speciality==speciality).ToList();

            }

            ViewBag.drs = drs;
            ViewBag.id=ptId;
            ViewBag.name = name;
            ViewBag.speciality = speciality;
            return View();
        }
        public IActionResult SearchDoctorPage(int id)
        {
            List<Doctor> drs = _context.Doctors.ToList();
            ViewBag.drs = drs;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> AddMessage(int ptid, Messages msg)
        {
            Patient pt = _context.Patients.Where(s => s.Id == ptid).First();
            msg.DateMsg = DateTime.Now;
            msg.Name = pt.fname + " " + pt.mname + " " + pt.lname;
          
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Messages.Add(msg);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("SendMessage", new { id = ptid });
                }
            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("SendMessage", new { id = ptid });
        }
        public IActionResult ReminderPage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Patient pt = _context.Patients.Where(s => s.username == username).First();
            int id = pt.Id;
            List<Reminder_Patient> rds = _context.Reminder_Patients.Where(s => s.PatientId == id).ToList();
            ViewBag.rds = rds;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> ReminderAdd(int ptid, Reminder_Patient rd)
        {
            ViewBag.id = ptid;
            rd.PatientId = ptid;
            try
            {

                _context.Reminder_Patients.Add(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = ptid });

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ReminderPage", new { id = ptid });
        }
        public async Task<IActionResult> DeleteReminder(int ptId, int remId)
        {
            Reminder_Patient rd = _context.Reminder_Patients.Where(s => s.Id == remId).First();
            try
            {

                _context.Reminder_Patients.Remove(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = ptId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ReminderPage", new { id = ptId });
        }
        public IActionResult SendMessage()
        {

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Patient pt = _context.Patients.Where(s => s.username == username).First();
            int id = pt.Id;
            ViewBag.id = id;
           
            String name = pt.fname + " " + pt.mname + " " + pt.lname;
            List<Messages> msgs = _context.Messages.Where(s => s.Name.Equals(name)).ToList();
            ViewBag.msgs = msgs;
            return View();
        }
        public IActionResult ViewProfile() {

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Patient pt = _context.Patients.Where(s => s.username == username).First();
            int id = pt.Id;
           
            ViewBag.pt = pt;
            ViewBag.id = id;
            return View();  
        }

    }
}