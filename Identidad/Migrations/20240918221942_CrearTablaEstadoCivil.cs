using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identidad.Migrations
{
    public partial class CrearTablaEstadoCivil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoCivilId",
                schema: "Iden",
                table: "PersonaME",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoCivilId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstadoCivilME",
                schema: "Iden",
                columns: table => new
                {
                    EstadoCivilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoCivilME", x => x.EstadoCivilId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonaME_EstadoCivilId",
                schema: "Iden",
                table: "PersonaME",
                column: "EstadoCivilId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EstadoCivilId",
                table: "AspNetUsers",
                column: "EstadoCivilId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_EstadoCivilME_EstadoCivilId",
                table: "AspNetUsers",
                column: "EstadoCivilId",
                principalSchema: "Iden",
                principalTable: "EstadoCivilME",
                principalColumn: "EstadoCivilId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaME_EstadoCivilME_EstadoCivilId",
                schema: "Iden",
                table: "PersonaME",
                column: "EstadoCivilId",
                principalSchema: "Iden",
                principalTable: "EstadoCivilME",
                principalColumn: "EstadoCivilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_EstadoCivilME_EstadoCivilId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaME_EstadoCivilME_EstadoCivilId",
                schema: "Iden",
                table: "PersonaME");

            migrationBuilder.DropTable(
                name: "EstadoCivilME",
                schema: "Iden");

            migrationBuilder.DropIndex(
                name: "IX_PersonaME_EstadoCivilId",
                schema: "Iden",
                table: "PersonaME");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_EstadoCivilId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EstadoCivilId",
                schema: "Iden",
                table: "PersonaME");

            migrationBuilder.DropColumn(
                name: "EstadoCivilId",
                table: "AspNetUsers");
        }
    }
}
