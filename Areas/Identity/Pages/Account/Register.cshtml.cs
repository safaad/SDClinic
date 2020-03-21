using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _context;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
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

            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string fname { get; set; }
            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string mname { get; set; }
            [StringLength(50, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")]
            public string lname { get; set; }
            [StringLength(10, ErrorMessage = "Maximum length is {1}")]
            [RegularExpression("^[A-Za-z]+$")] public string Gender { get; set; }
            public DateTime? Birthday { get; set; }

            [StringLength(100, ErrorMessage = "Maximum length is {1}")]
            public string Address { get; set; }

            [StringLength(400, ErrorMessage = "Maximum length is {1}")]
            public string About { get; set; }


            [StringLength(100)]
            public string Speciality { get; set; }
            [StringLength(100)]
            public string Time { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Admin/ManageDoctor");
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var userOld = await _userManager.GetUserAsync(HttpContext.User);
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    Task<IdentityResult> newUserRole = _userManager.AddToRoleAsync(user, "Doctor");
                    newUserRole.Wait();
                    var dr = new Doctor
                    {
                        username=user.Id,
                        fname = Input.fname,
                        mname = Input.mname,
                        lname = Input.lname,
                        Gender = Input.Gender,
                        Birthday = Input.Birthday,
                        Address = Input.Address,
                        About = Input.About,
                        Speciality = Input.Speciality,
                        Time = Input.Time,
                    };
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    _context.Doctors.Add(dr);
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
