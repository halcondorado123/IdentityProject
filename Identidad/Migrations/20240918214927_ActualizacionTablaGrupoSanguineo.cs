using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identidad.Migrations
{
    public partial class ActualizacionTablaGrupoSanguineo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupSanguineo",
                schema: "Iden",
                table: "GrupoSanguineoME");

            migrationBuilder.AddColumn<string>(
                name: "GrupoSanguineo",
                schema: "Iden",
                table: "GrupoSanguineoME",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GrupoSanguineo",
                schema: "Iden",
                table: "GrupoSanguineoME");

            migrationBuilder.AddColumn<string>(
                name: "GrupSanguineo",
                schema: "Iden",
                table: "GrupoSanguineoME",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
