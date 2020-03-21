using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDClinic.Models;

namespace SDClinic.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Doctor", NormalizedName = "DOCTOR" },
                new { Id = "3", Name = "Assistant", NormalizedName = "ASSISTANT" },
                new { Id = "4", Name = "Patient", NormalizedName = "PATIENT" },
                new { Id = "5", Name = "InsuranceCompany", NormalizedName = "INSURANCECOMPANY" }
                );

            builder.Entity<InsuranceCompany>()
                .HasKey(o => new { o.Id, o.Name });

            builder.Entity<Patient>()
            .HasOne(s => s.insurance_company)
            .WithMany(c => c.patients)
            .HasForeignKey(s => s.pat_insurance_company_name)
            .HasPrincipalKey(c => c.Name);



        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Date> Dates { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<InsuranceCompany> Insurance_Companies { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Reminder_Admin> Reminder_Admins { get; set; }
        public DbSet<Reminder_Assistant> Reminder_Assistants { get; set; }
        public DbSet<Reminder_Doctor> Reminder_Doctors { get; set; }
        public DbSet<Reminder_Insurance> Reminder_Insurances { get; set; }
        public DbSet<Reminder_Patient> Reminder_Patients { get; set; }
        public DbSet<Report> Reports { get; set; }


    }
}
