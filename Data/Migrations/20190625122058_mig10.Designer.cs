﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDClinic.Data;

namespace SDClinic.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190625122058_mig10")]
    partial class mig10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = "3",
                            Name = "Assistant",
                            NormalizedName = "ASSISTANT"
                        },
                        new
                        {
                            Id = "4",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        },
                        new
                        {
                            Id = "5",
                            Name = "InsuranceCompany",
                            NormalizedName = "INSURANCECOMPANY"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SDClinic.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("fname")
                        .HasMaxLength(50);

                    b.Property<string>("lname")
                        .HasMaxLength(50);

                    b.Property<string>("mname")
                        .HasMaxLength(50);

                    b.Property<string>("username");

                    b.HasKey("Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("SDClinic.Models.Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId");

                    b.Property<string>("FName")
                        .HasMaxLength(50);

                    b.Property<string>("LName")
                        .HasMaxLength(50);

                    b.Property<string>("MName")
                        .HasMaxLength(50);

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Assistants");
                });

            modelBuilder.Entity("SDClinic.Models.Consultation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BloodPressure")
                        .HasMaxLength(5);

                    b.Property<string>("Cost")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime?>("Date");

                    b.Property<string>("Diagnoses")
                        .HasMaxLength(500);

                    b.Property<int>("DoctorId");

                    b.Property<string>("Insurance_Confirmation")
                        .HasMaxLength(10);

                    b.Property<int>("PatientId");

                    b.Property<string>("Symptoms")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("Temp")
                        .HasMaxLength(5);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("Treatment")
                        .HasMaxLength(100);

                    b.Property<string>("Type")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("SDClinic.Models.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.Property<DateTime?>("date_dateTime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("SDClinic.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("About")
                        .HasMaxLength(400);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Gender")
                        .HasMaxLength(10);

                    b.Property<string>("Speciality")
                        .HasMaxLength(100);

                    b.Property<string>("Time")
                        .HasMaxLength(100);

                    b.Property<string>("fname")
                        .HasMaxLength(50);

                    b.Property<string>("lname")
                        .HasMaxLength(50);

                    b.Property<string>("mname")
                        .HasMaxLength(50);

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SDClinic.Models.InsuranceCompany", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("Address")
                        .HasMaxLength(100);

                    b.Property<string>("Fax")
                        .HasMaxLength(100);

                    b.Property<string>("username")
                        .IsRequired();

                    b.HasKey("Id", "Name");

                    b.ToTable("Insurance_Companies");
                });

            modelBuilder.Entity("SDClinic.Models.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DoctorId");

                    b.Property<int>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("SDClinic.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime?>("DateMsg")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SDClinic.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("BloodType")
                        .HasMaxLength(4);

                    b.Property<string>("Gender")
                        .HasMaxLength(10);

                    b.Property<string>("Picture")
                        .HasMaxLength(500);

                    b.Property<string>("fname")
                        .HasMaxLength(50);

                    b.Property<string>("lname")
                        .HasMaxLength(50);

                    b.Property<string>("mname")
                        .HasMaxLength(50);

                    b.Property<string>("pat_insurance_company_name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("username");

                    b.HasKey("Id");

                    b.HasIndex("pat_insurance_company_name");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AdminId");

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateTime");

                    b.Property<string>("Priority")
                        .HasMaxLength(12);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.ToTable("Reminder_Admins");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Assistant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssistantId");

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateTime");

                    b.Property<string>("Priority")
                        .HasMaxLength(12);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AssistantId");

                    b.ToTable("Reminder_Assistants");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateTime");

                    b.Property<int>("DoctorId");

                    b.Property<string>("Priority")
                        .HasMaxLength(12);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Reminder_Doctors");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Insurance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateTime");

                    b.Property<int?>("Insurance_CompanyId");

                    b.Property<string>("Insurance_CompanyName");

                    b.Property<string>("Insurance_CompanyName1");

                    b.Property<string>("Priority")
                        .HasMaxLength(12);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Insurance_CompanyId", "Insurance_CompanyName1");

                    b.ToTable("Reminder_Insurances");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasMaxLength(300);

                    b.Property<DateTime?>("DateTime");

                    b.Property<int>("PatientId");

                    b.Property<string>("Priority")
                        .HasMaxLength(12);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Reminder_Patients");
                });

            modelBuilder.Entity("SDClinic.Models.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConsultationId");

                    b.Property<int?>("InsuranceCompanyId");

                    b.Property<string>("InsuranceCompanyName");

                    b.Property<string>("ReportId")
                        .IsRequired();

                    b.Property<int>("report_cons_id");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.HasIndex("InsuranceCompanyId", "InsuranceCompanyName");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Assistant", b =>
                {
                    b.HasOne("SDClinic.Models.Doctor", "Doctor")
                        .WithMany("Assistants")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Consultation", b =>
                {
                    b.HasOne("SDClinic.Models.Doctor", "Doctor")
                        .WithMany("consultations")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SDClinic.Models.Patient", "Patient")
                        .WithMany("consultations")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Date", b =>
                {
                    b.HasOne("SDClinic.Models.Doctor", "Doctor")
                        .WithMany("dates")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SDClinic.Models.Patient", "Patient")
                        .WithMany("dates")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.List", b =>
                {
                    b.HasOne("SDClinic.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SDClinic.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Patient", b =>
                {
                    b.HasOne("SDClinic.Models.InsuranceCompany", "insurance_company")
                        .WithMany("patients")
                        .HasForeignKey("pat_insurance_company_name")
                        .HasPrincipalKey("Name")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Admin", b =>
                {
                    b.HasOne("SDClinic.Models.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Assistant", b =>
                {
                    b.HasOne("SDClinic.Models.Assistant", "Assistant")
                        .WithMany()
                        .HasForeignKey("AssistantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Doctor", b =>
                {
                    b.HasOne("SDClinic.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Insurance", b =>
                {
                    b.HasOne("SDClinic.Models.InsuranceCompany", "Insurance_Company")
                        .WithMany()
                        .HasForeignKey("Insurance_CompanyId", "Insurance_CompanyName1");
                });

            modelBuilder.Entity("SDClinic.Models.Reminder_Patient", b =>
                {
                    b.HasOne("SDClinic.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SDClinic.Models.Report", b =>
                {
                    b.HasOne("SDClinic.Models.Consultation")
                        .WithMany("reports")
                        .HasForeignKey("ConsultationId");

                    b.HasOne("SDClinic.Models.InsuranceCompany")
                        .WithMany("reports")
                        .HasForeignKey("InsuranceCompanyId", "InsuranceCompanyName");
                });
#pragma warning restore 612, 618
        }
    }
}
