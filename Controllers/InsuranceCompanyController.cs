using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDClinic.Data;
using SDClinic.Models;

namespace SDClinic.Controllers
{
    [Authorize(Roles = "InsuranceCompany")]

    public class InsuranceCompanyController : Controller
    {
        private readonly ApplicationDbContext _context;
        public InsuranceCompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            InsuranceCompany ins = _context.Insurance_Companies.Where(s => s.username == username).First();
            //List<Report> reports = _context.Reports.Where(s => s.InsuranceCompany.Id == id).ToList();
            List<Consultation> cons = _context.Consultations.Where(s => s.Patient.pat_insurance_company_name == ins.Name).Include(s=>s.Doctor).Include(s=>s.Patient).ToList();
            ViewBag.id = ins.Name;
            ViewBag.ins = ins;
            ViewBag.cons = cons;
            return View();
        }
        public IActionResult SearchReport(String id,String patname) {
            if (patname == null) {
                return RedirectToAction("Index", new { id = id});
            }
            List<Consultation> cons = _context.Consultations.Where(s => s.Patient.pat_insurance_company_name == id).Where(s => ("" + s.Patient.fname + " " + s.Patient.mname + " " + s.Patient.lname).Contains(patname)).Include(s => s.Doctor).Include(s => s.Patient).ToList();
            InsuranceCompany ins = _context.Insurance_Companies.Where(s => s.Name == id).First();
            ViewBag.id = id;
            ViewBag.ins = ins;
            ViewBag.cons = cons;
            ViewBag.patname = patname;
            return View();

        }
        public async Task<IActionResult> UpdateConsultation(String insname,int consid,String confirmation)
        {
            Consultation cons = _context.Consultations.Where(s => s.Id == consid).First();
            cons.Insurance_Confirmation = confirmation;
            try
            {
                _context.Consultations.Update(cons);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { id = insname });
            }
            catch (DbUpdateException )
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }
            return RedirectToAction("Index", new { id = insname });
        }
        public IActionResult ReminderPage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            InsuranceCompany ins = _context.Insurance_Companies.Where(s => s.username == username).First();
            String id = ins.Name;
            List<Reminder_Insurance> rds = _context.Reminder_Insurances.Where(s => s.Insurance_CompanyName == id).ToList();
            ViewBag.rds = rds;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> ReminderAdd(String insid, Reminder_Insurance rd)
        {
            ViewBag.id = insid;

            try
            {

                _context.Reminder_Insurances.Add(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = insid });

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ReminderPage", new { id = insid });
        }
        public async Task<IActionResult> DeleteReminder(String insId, int remId)
        {
            Reminder_Insurance rd = _context.Reminder_Insurances.Where(s => s.Id == remId).First();
            try
            {

                _context.Reminder_Insurances.Remove(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage", new { id = insId });

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ReminderPage", new { id = insId });
        }
        public async Task<IActionResult> AddMessage(String insid, Messages msg)
        {
     
            msg.Name = insid;

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Messages.Add(msg);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("SendMessage", new { id = insid });
                }
            }
            catch (DbUpdateException)
            {

                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return RedirectToAction("SendMessage", new { id = insid });
        }
        public IActionResult SendMessage()
        {

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            InsuranceCompany ins = _context.Insurance_Companies.Where(s => s.username == username).First();
            String id = ins.Name;
            ViewBag.id = id;
  
            List<Messages> msgs = _context.Messages.Where(s => s.Name.Equals(id)).ToList();
            ViewBag.msgs = msgs;
            return View();
        }
        public IActionResult ViewProfile()
        {

            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            InsuranceCompany ins = _context.Insurance_Companies.Where(s => s.username == username).First();
            String id = ins.Name;
            ViewBag.id = id;
            ViewBag.ins = ins;
            return View();
              
        }
    }
}