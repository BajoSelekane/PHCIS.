using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedClinics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUser",
                schema: "identity",
                table: "ApplicationUser");

            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "identity",
                newName: "Users",
                newSchema: "identity");

            migrationBuilder.AddColumn<string>(
                name: "ClinicsId",
                schema: "identity",
                table: "Appointments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "identity",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Clinics",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Users_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ClinicsId",
                schema: "identity",
                table: "Appointments",
                column: "ClinicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ApplicationUserId",
                schema: "identity",
                table: "Roles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Clinics_ClinicsId",
                schema: "identity",
                table: "Appointments",
                column: "ClinicsId",
                principalSchema: "identity",
                principalTable: "Clinics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Clinics_ClinicsId",
                schema: "identity",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "Clinics",
                schema: "identity");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "identity");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ClinicsId",
                schema: "identity",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ClinicsId",
                schema: "identity",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Password",
                schema: "identity",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "identity",
                newName: "ApplicationUser",
                newSchema: "identity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUser",
                schema: "identity",
                table: "ApplicationUser",
                column: "Id");
        }
    }
}
