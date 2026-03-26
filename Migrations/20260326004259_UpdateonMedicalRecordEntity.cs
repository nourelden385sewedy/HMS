using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Migrations
{
    /// <inheritdoc />
    public partial class UpdateonMedicalRecordEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdated",
                table: "MedicalRecords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 21, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 28, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4685));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 6, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 23, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4679));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 27, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 25, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4688));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AppointmentDate",
                value: new DateTime(2026, 4, 5, 2, 42, 58, 539, DateTimeKind.Local).AddTicks(4690));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "LastUpdated",
                table: "MedicalRecords",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 21, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 28, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7509));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 6, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 23, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7504));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 27, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7506));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6,
                column: "AppointmentDate",
                value: new DateTime(2026, 3, 25, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7511));

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7,
                column: "AppointmentDate",
                value: new DateTime(2026, 4, 5, 2, 36, 56, 875, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastUpdated",
                value: new DateOnly(2026, 1, 15));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastUpdated",
                value: new DateOnly(2026, 2, 10));

            migrationBuilder.UpdateData(
                table: "MedicalRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastUpdated",
                value: new DateOnly(2026, 3, 1));
        }
    }
}
