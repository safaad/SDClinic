using Microsoft.AspNetCore.Identity;
using SDClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDClinic.Data
{
    public class InitializeData
    {
        public static async Task Initialize(ApplicationDbContext context,
                               UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            context.Database.EnsureCreated();

            if (await userManager.FindByEmailAsync("admin@admin.com") == null)
            {
                var user = new IdentityUser { UserName = "admin@admin.com", Email = "admin@admin.com" };

                var result = await userManager.CreateAsync(user, "Pass.1234");
                if (result.Succeeded)
                {

                    Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(user, "Admin");
                    newUserRole.Wait();
                    var admin = new Admin
                    {
                        username = user.Id,
                        fname = "admin",
                        mname = "admin",
                        lname = "admin",

                    };
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    context.Admins.Add(admin);
                    context.SaveChanges();
                }
            }
        }
    }
}
