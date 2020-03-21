using System;
using System.Collections.Generic;
using System.Data;
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
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        public AdminController(UserManager<IdentityUser> userManager,
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
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            ViewBag.id = admin.Id;
            return View();
        }
        public IActionResult ViewMessages() {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            List<Messages> msgs = _context.Messages.ToList();
            ViewBag.msgs = msgs;
            ViewBag.id = admin.Id;
            return View();
        }
        public IActionResult ManageDoctor()
        {
            List<Doctor> drs = _context.Doctors.ToList();
            ViewBag.drs = drs;
            return View();
        }
        public IActionResult EditDoctor(int drId)
        {
            List<Doctor> drs = _context.Doctors.ToList();
            Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            var userdr = _userManager.FindByIdAsync(dr.username);
            ViewBag.drs = drs;
            ViewBag.dr = dr;
            ViewBag.userdr = userdr;
            return View();
        }
        public async Task<IActionResult> UpdateDoctor(Doctor dr)
        {
            try
            {
                _context.Doctors.Update(dr);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageDoctor");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageDoctor");
        }
        public IActionResult ViewDoctor(int drId)
        {
            Doctor dr = _context.Doctors.Where(s => s.Id == drId).First();
            var userdr = _userManager.FindByIdAsync(dr.username);
            ViewBag.dr = dr;
            ViewBag.userdr = userdr;
            return View();
        }
        public async Task<IActionResult> DeleteDoctor(int drid)
        {
            Doctor a = _context.Doctors.Where(s => s.Id == drid).First();

            var user = await _userManager.FindByIdAsync(a.username);
            try
            {

                _context.Doctors.Remove(a);
                await _userManager.DeleteAsync(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("ManageDoctor");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ManageDoctor");
        }
        public IActionResult ManageAssistant()
        {
            List<Assistant> assists = _context.Assistants.Include(s=>s.Doctor).ToList();
            ViewBag.assists = assists;
            return View();
        }
        public IActionResult ManageAdmin()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            List<Admin> admins = _context.Admins.ToList();
            ViewBag.admins = admins;
            ViewBag.id = admin.Id;
            return View();
        }
        public IActionResult ManageInsurance()
        {
            List<InsuranceCompany> inss = _context.Insurance_Companies.Include(s=>s.patients).ToList();
            ViewBag.inss = inss;
            return View();
        }
        public async Task<IActionResult> DeleteAdmin(int adminid)
        {
            Admin a = _context.Admins.Where(s => s.Id == adminid).First();
         
            var user = await _userManager.FindByIdAsync(a.username);
            try
            {

                _context.Admins.Remove(a);
                await _userManager.DeleteAsync(user);

                await _context.SaveChangesAsync();
    
                return RedirectToAction("ManageAdmin");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
         
           
            return RedirectToAction("ManageAdmin");
        }
        public async Task<IActionResult> DeleteAssistant(int asisid)
        {
            Assistant a = _context.Assistants.Where(s => s.Id == asisid).First();

            var user = await _userManager.FindByIdAsync(a.username);
            try
            {

                _context.Assistants.Remove(a);
                await _userManager.DeleteAsync(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("ManageAssistant");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ManageAssistant");
        }
        public async Task<IActionResult> DeleteInsurance(int insid)
        {
            InsuranceCompany a = _context.Insurance_Companies.Where(s => s.Id == insid).First();

            var user = await _userManager.FindByIdAsync(a.username);
            try
            {

                _context.Insurance_Companies.Remove(a);
                await _userManager.DeleteAsync(user);

                await _context.SaveChangesAsync();

                return RedirectToAction("ManageInsurance");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ManageInsurance");
        }

        public IActionResult EditAdmin(int adminid)
        {
            Admin a = _context.Admins.Where(s => s.Id == adminid).First();
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
      
            List<Admin> admins = _context.Admins.ToList();
            ViewBag.admins = admins;
        
            ViewBag.admin = a;
            ViewBag.id = admin.Id;
            return View();
        }
        public async Task<IActionResult> UpdateAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Update(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageAdmin");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageAdmin");
        }

        //public async Task<IActionResult> UpdateDoctor(Doctor dr)
        //{
        //    try
        //    {
        //        _context.Doctors.Update(dr);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("ManageDoctor");
        //    }
        //    catch (DbUpdateException)
        //    {
        //        ModelState.AddModelError("", "Unable to save changes. " +
        //            "Try again, and if the problem persists, " +
        //            "see your system administrator.");
        //    }

        //    return RedirectToAction("ManageDoctor");
        //}
        public IActionResult EditInsurance(int insid)
        {
            InsuranceCompany a = _context.Insurance_Companies.Where(s => s.Id == insid).First();
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<InsuranceCompany> inss = _context.Insurance_Companies.Include(s => s.patients).ToList();
            ViewBag.inss = inss;
            ViewBag.ins = a;

            return View();
        }
        public async Task<IActionResult> UpdateInsurance(InsuranceCompany ins)
        {
            try
            {
                _context.Insurance_Companies.Update(ins);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageInsurance");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageInsurance");
        }
        public IActionResult EditAssistant(int asisid)
        {
            Assistant a = _context.Assistants.Where(s => s.Id == asisid).Include(s=>s.Doctor).First();
            List<Doctor> drs = _context.Doctors.ToList();
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Assistant> assists = _context.Assistants.Include(s => s.Doctor).ToList();
            ViewBag.assists = assists;
            ViewBag.asis = a;
            ViewBag.drs = drs;
            return View();
        }
        public async Task<IActionResult> UpdateAssistant(Assistant asis)
        {
            if (asis == null)
            {
                throw new ArgumentNullException(nameof(asis));
            }

            try
            {
                _context.Assistants.Update(asis);
                await _context.SaveChangesAsync();
                return RedirectToAction("ManageAssistant");
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists, " +
                    "see your system administrator.");
            }

            return RedirectToAction("ManageAssistant");
        }
        public IActionResult ReminderPage()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            int id = admin.Id;
            List<Reminder_Admin> rds = _context.Reminder_Admins.Where(s => s.AdminId == id).ToList();
            ViewBag.rds = rds;
            ViewBag.id = id;
            return View();
        }
        public async Task<IActionResult> ReminderAdd( Reminder_Admin rd)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            int id = admin.Id;
            ViewBag.id = id;

            try
            {

                _context.Reminder_Admins.Add(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage");

            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }


            return RedirectToAction("ReminderPage");
        }
        public async Task<IActionResult> DeleteReminder(int remId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            int id = admin.Id;
            
            Reminder_Admin rd = _context.Reminder_Admins.Where(s => s.Id == remId).First();
            try
            {

                _context.Reminder_Admins.Remove(rd);
                await _context.SaveChangesAsync();
                return RedirectToAction("ReminderPage");

            }
            catch (DbUpdateException)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("ReminderPage");
        }
        public IActionResult ViewProfile()
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Admin admin = _context.Admins.Where(s => s.username == username).First();
            int id = admin.Id;
            ViewBag.id = id;
            ViewBag.admin = admin;
            return View();
        }

    }

}