using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointments.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateforeignkey2 : Migration
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
                name: "patientId",
                table: "appointments",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "doctorId",
                table: "appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_patientId",
                table: "appointments",
                newName: "IX_appointments_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_doctorId",
                table: "appointments",
                newName: "IX_appointments_DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PateintId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_workingHours_doctors_DoctorId",
                table: "workingHours",
                column: "DoctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_DoctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_workingHours_doctors_DoctorId",
                table: "workingHours");

            migrationBuilder.DropColumn(
                name: "PateintId",
                table: "appointments");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "workingHours",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_workingHours_DoctorId",
                table: "workingHours",
                newName: "IX_workingHours_doctorId");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "appointments",
                newName: "patientId");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "appointments",
                newName: "doctorId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_PatientId",
                table: "appointments",
                newName: "IX_appointments_patientId");

            migrationBuilder.RenameIndex(
                name: "IX_appointments_DoctorId",
                table: "appointments",
                newName: "IX_appointments_doctorId");

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
                name: "FK_workingHours_doctors_doctorId",
                table: "workingHours",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
