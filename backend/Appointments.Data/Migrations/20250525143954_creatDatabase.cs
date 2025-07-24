using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointments.Data.Migrations
{
    /// <inheritdoc />
    public partial class creatDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "PateintId",
                table: "appointments");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "PateintId",
                table: "appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_patients_PatientId",
                table: "appointments",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id");
        }
    }
}
