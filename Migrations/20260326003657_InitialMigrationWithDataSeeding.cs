using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrationWithDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Treatment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateOnly>(type: "date", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientPhones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientPhones_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology (القلب)" },
                    { 2, "Pediatrics (الأطفال)" },
                    { 3, "Orthopedics (العظام)" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "DateOfBirth", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "m.youssef@gmail.com", "Mohamed Youssef El-Sherif" },
                    { 2, new DateTime(1992, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara.m88@yahoo.com", "Sara Mahmoud Ibrahim" },
                    { 3, new DateTime(2015, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar.fayoumy@outlook.com", "Omar Khaled El-Fayoumy" },
                    { 4, new DateTime(1990, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "layla.a@gmail.com", "Layla Ahmed Mahmoud" },
                    { 5, new DateTime(1978, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hassan.ali@gmail.com", "Hassan Ali Mansour" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "DepartmentId", "Email", "Name", "Salary", "Specialization" },
                values: new object[,]
                {
                    { 1, 1, "ahmed@hms.com", "Dr. Ahmed Mansour", 45000m, "Consultant" },
                    { 2, 2, "mona@hms.com", "Dr. Mona Abdel-Aziz", 38000m, "Surgeon" },
                    { 3, 3, "tarek@hms.com", "Dr. Tarek El-Shennawy", 42000m, "Specialist" },
                    { 4, 1, "khaled@hms.com", "Dr. Khaled Hassan", 40000m, "Cardiologist" },
                    { 5, 2, "fatma@hms.com", "Dr. Fatma El-Zahraa", 37000m, "Pediatrician" }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "Diagnosis", "LastUpdated", "PatientId", "Treatment" },
                values: new object[,]
                {
                    { 1, "Hypertension", new DateOnly(2026, 1, 15), 1, "Meds" },
                    { 2, "ACL Repair", new DateOnly(2026, 2, 10), 2, "PT" },
                    { 3, "Seasonal Allergy", new DateOnly(2026, 3, 1), 4, "Antihistamines" }
                });

            migrationBuilder.InsertData(
                table: "PatientPhones",
                columns: new[] { "Id", "PatientId", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "01012345678" },
                    { 2, 1, "01198765432" },
                    { 3, 2, "01255544433" },
                    { 4, 3, "01500011122" },
                    { 5, 4, "01099988877" },
                    { 6, 5, "01122233344" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "DoctorId", "Notes", "PatientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 21, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7451), 1, "Checkup", 1, "Completed" },
                    { 2, new DateTime(2026, 3, 28, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7509), 2, "Vaccination", 3, "Scheduled" },
                    { 3, new DateTime(2026, 3, 6, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7516), 3, "Post-surgery", 2, "Completed" },
                    { 4, new DateTime(2026, 3, 23, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7504), 1, "Follow-up", 2, "Completed" },
                    { 5, new DateTime(2026, 3, 27, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7506), 4, "New Patient", 4, "Scheduled" },
                    { 6, new DateTime(2026, 3, 25, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7511), 5, "Routine check", 5, "Completed" },
                    { 7, new DateTime(2026, 4, 5, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7514), 5, "Monthly review", 3, "Scheduled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                table: "Doctors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientPhones_PatientId",
                table: "PatientPhones",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_Email",
                table: "Patients",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "PatientPhones");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
