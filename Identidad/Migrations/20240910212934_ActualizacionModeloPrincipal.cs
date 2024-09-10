using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identidad.Migrations
{
    public partial class ActualizacionModeloPrincipal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmailInstitucional",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "EmailInstitucional",
                table: "Usuarios",
                newName: "EmailCorporativo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailCorporativo",
                table: "Usuarios",
                newName: "EmailInstitucional");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailInstitucional",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
