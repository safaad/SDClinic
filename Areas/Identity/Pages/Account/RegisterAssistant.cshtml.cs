using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SDClinic.Data;
using SDClinic.Models;

namespace SDClinic.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterAssistantModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterAssistantModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        public RegisterAssistantModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterAssistantModel> logger,
            IEmailSender emailSender, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public int DoctorId { get; set; }


            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string FName { get; set; }

            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string MName { get; set; }

            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string LName { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Admin/ManageAssistant");
            if (ModelState.IsValid)
            {
                var userOld = await _userManager.GetUserAsync(HttpContext.User);
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                if (!_context.Doctors.Any(s => s.Id == Input.DoctorId)) {
                    return Page();
                }
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(user, "Assistant");
                    newUserRole.Wait();
                    var asis = new Assistant
                    {
                        username=user.Id,
                        FName=Input.FName,
                        MName=Input.MName,
                        LName=Input.LName,
                        DoctorId=Input.DoctorId,
                    };
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    _context.Assistants.Add(asis);
                    _context.SaveChanges();
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(userOld, isPersistent: false);
                   
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
