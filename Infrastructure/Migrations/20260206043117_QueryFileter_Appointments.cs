using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class QueryFileter_Appointments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppointmentId",
                schema: "identity",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_AppointmentId",
                schema: "identity",
                table: "Patients",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Appointments_AppointmentId",
                schema: "identity",
                table: "Patients",
                column: "AppointmentId",
                principalSchema: "identity",
                principalTable: "Appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Appointments_AppointmentId",
                schema: "identity",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_AppointmentId",
                schema: "identity",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                schema: "identity",
                table: "Patients");
        }
    }
}
