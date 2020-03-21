using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SDClinic.Data.Migrations
{
    public partial class trial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: false),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    About = table.Column<string>(maxLength: 400, nullable: true),
                    Speciality = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurance_Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    username = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    Fax = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance_Companies", x => new { x.Id, x.Name });
                    table.UniqueConstraint("AK_Insurance_Companies_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Subject = table.Column<string>(maxLength: 150, nullable: false),
                    Message = table.Column<string>(maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_Admins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Priority = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    AdminId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Admins_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(maxLength: 300, nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DoctorId = table.Column<int>(nullable: false),
                    FName = table.Column<string>(maxLength: 50, nullable: true),
                    MName = table.Column<string>(maxLength: 50, nullable: true),
                    LName = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistants_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Priority = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Doctors_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fname = table.Column<string>(maxLength: 50, nullable: true),
                    mname = table.Column<string>(maxLength: 50, nullable: true),
                    lname = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    BloodType = table.Column<string>(maxLength: 4, nullable: true),
                    Picture = table.Column<string>(maxLength: 500, nullable: true),
                    pat_insurance_company_name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Insurance_Companies_pat_insurance_company_name",
                        column: x => x.pat_insurance_company_name,
                        principalTable: "Insurance_Companies",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_Insurances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Priority = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    Insurance_CompanyId1 = table.Column<int>(nullable: true),
                    Insurance_CompanyName = table.Column<string>(nullable: true),
                    Insurance_CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Insurances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Insurances_Insurance_Companies_Insurance_CompanyId1_Insurance_CompanyName",
                        columns: x => new { x.Insurance_CompanyId1, x.Insurance_CompanyName },
                        principalTable: "Insurance_Companies",
                        principalColumns: new[] { "Id", "Name" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Priority = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    AssistantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Assistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Assistants_Assistants_AssistantId",
                        column: x => x.AssistantId,
                        principalTable: "Assistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    Symptoms = table.Column<string>(maxLength: 500, nullable: false),
                    Diagnoses = table.Column<string>(maxLength: 500, nullable: true),
                    Temp = table.Column<string>(maxLength: 5, nullable: true),
                    BloodPressure = table.Column<string>(maxLength: 5, nullable: true),
                    Cost = table.Column<string>(maxLength: 10, nullable: false),
                    Treatment = table.Column<string>(maxLength: 100, nullable: true),
                    Insurance_Confirmation = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    date_dateTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dates_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dates_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lists_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reminder_Patients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: true),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Priority = table.Column<string>(maxLength: 10, nullable: true),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Time = table.Column<TimeSpan>(nullable: true),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminder_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reminder_Patients_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    report_cons_id = table.Column<int>(nullable: false),
                    ReportId = table.Column<string>(nullable: false),
                    Date = table.Column<string>(maxLength: 50, nullable: true),
                    ConsultationId = table.Column<int>(nullable: true),
                    InsuranceCompanyId = table.Column<int>(nullable: true),
                    InsuranceCompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Consultations_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "Consultations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Insurance_Companies_InsuranceCompanyId_InsuranceCompanyName",
                        columns: x => new { x.InsuranceCompanyId, x.InsuranceCompanyName },
                        principalTable: "Insurance_Companies",
                        principalColumns: new[] { "Id", "Name" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "Doctor", "DOCTOR" },
                    { "3", null, "Assistant", "ASSISTANT" },
                    { "4", null, "Patient", "PATIENT" },
                    { "5", null, "InsuranceCompany", "INSURANCECOMPANY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assistants_DoctorId",
                table: "Assistants",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_DoctorId",
                table: "Consultations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientId",
                table: "Consultations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_DoctorId",
                table: "Dates",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dates_PatientId",
                table: "Dates",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_DoctorId",
                table: "Lists",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_PatientId",
                table: "Lists",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_pat_insurance_company_name",
                table: "Patients",
                column: "pat_insurance_company_name");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Admins_AdminId",
                table: "Reminder_Admins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Assistants_AssistantId",
                table: "Reminder_Assistants",
                column: "AssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Doctors_DoctorId",
                table: "Reminder_Doctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Insurances_Insurance_CompanyId1_Insurance_CompanyName",
                table: "Reminder_Insurances",
                columns: new[] { "Insurance_CompanyId1", "Insurance_CompanyName" });

            migrationBuilder.CreateIndex(
                name: "IX_Reminder_Patients_PatientId",
                table: "Reminder_Patients",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ConsultationId",
                table: "Reports",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_InsuranceCompanyId_InsuranceCompanyName",
                table: "Reports",
                columns: new[] { "InsuranceCompanyId", "InsuranceCompanyName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dates");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Reminder_Admins");

            migrationBuilder.DropTable(
                name: "Reminder_Assistants");

            migrationBuilder.DropTable(
                name: "Reminder_Doctors");

            migrationBuilder.DropTable(
                name: "Reminder_Insurances");

            migrationBuilder.DropTable(
                name: "Reminder_Patients");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Insurance_Companies");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5");
        }
    }
}
