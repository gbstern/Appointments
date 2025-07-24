using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointments.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateforeignkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialties_SpecialtyId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_workingHours_doctors_DoctorId",
                table: "workingHours");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "workingHours",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_workingHours_DoctorId",
                table: "workingHours",
                newName: "IX_workingHours_doctorId");

            migrationBuilder.RenameColumn(
                name: "SpecialtyId",
                table: "doctors",
                newName: "specialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_doctors_SpecialtyId",
                table: "doctors",
                newName: "IX_doctors_specialtyId");

            migrationBuilder.AlterColumn<string>(
                name: "patientId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "doctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialties_specialtyId",
                table: "doctors",
                column: "specialtyId",
                principalTable: "specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workingHours_doctors_doctorId",
                table: "workingHours",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_specialties_specialtyId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_workingHours_doctors_doctorId",
                table: "workingHours");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "workingHours",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_workingHours_doctorId",
                table: "workingHours",
                newName: "IX_workingHours_DoctorId");

            migrationBuilder.RenameColumn(
                name: "specialtyId",
                table: "doctors",
                newName: "SpecialtyId");

            migrationBuilder.RenameIndex(
                name: "IX_doctors_specialtyId",
                table: "doctors",
                newName: "IX_doctors_SpecialtyId");

            migrationBuilder.AlterColumn<string>(
                name: "patientId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "doctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_patientId",
                table: "appointments",
                column: "patientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_specialties_SpecialtyId",
                table: "doctors",
                column: "SpecialtyId",
                principalTable: "specialties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_workingHours_doctors_DoctorId",
                table: "workingHours",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
