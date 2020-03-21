using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SDClinic.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace SDClinic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireLoggedIn", policy => policy.RequireRole("Admin", "Doctor", "Assistant", "Patient", "Insurance_company").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin").RequireAuthenticatedUser());
                options.AddPolicy("RequireDoctorRole", policy => policy.RequireRole("Doctor").RequireAuthenticatedUser());
                options.AddPolicy("RequireAssistantRole", policy => policy.RequireRole("Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequirePatientRole", policy => policy.RequireRole("Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireInsuranceRole", policy => policy.RequireRole("InsuranceCompany").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorRole", policy => policy.RequireRole("Admin", "Doctor").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminPatientRole", policy => policy.RequireRole("Admin", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantRole", policy => policy.RequireRole("Admin", "Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminInsuranceRole", policy => policy.RequireRole("Admin", "InsuranceCompany").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorPatientRole", policy => policy.RequireRole("Admin", "Doctor", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorAssistantRole", policy => policy.RequireRole("Admin", "Doctor", "Assistant").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminDoctorAssistantPatientRole", policy => policy.RequireRole("Admin", "Doctor", "Assistant", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantPatientRole", policy => policy.RequireRole("Admin", "Assistant", "Patient").RequireAuthenticatedUser());
                options.AddPolicy("RequireAdminAssistantInsuranceRole", policy => policy.RequireRole("Admin", "Assistant", "Insurance").RequireAuthenticatedUser());
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //InitializeData.Initialize(context,userManager,signInManager).Wait();
        }
    }
}
