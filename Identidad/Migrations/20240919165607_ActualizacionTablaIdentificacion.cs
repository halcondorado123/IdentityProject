using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identidad.Migrations
{
    public partial class ActualizacionTablaIdentificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDocumentoME_TipoDocumentoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaME_TipoDocumentoME_TipoDocumentoId",
                schema: "Iden",
                table: "PersonaME");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "Iden",
                table: "TipoDocumentoME",
                newName: "DocumentoId");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                newName: "TipoDocumentoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaME_TipoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                newName: "IX_PersonaME_TipoDocumentoDocumentoId");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoId",
                table: "AspNetUsers",
                newName: "TipoDocumentoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TipoDocumentoId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TipoDocumentoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDocumentoME_TipoDocumentoDocumentoId",
                table: "AspNetUsers",
                column: "TipoDocumentoDocumentoId",
                principalSchema: "Iden",
                principalTable: "TipoDocumentoME",
                principalColumn: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaME_TipoDocumentoME_TipoDocumentoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                column: "TipoDocumentoDocumentoId",
                principalSchema: "Iden",
                principalTable: "TipoDocumentoME",
                principalColumn: "DocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TipoDocumentoME_TipoDocumentoDocumentoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonaME_TipoDocumentoME_TipoDocumentoDocumentoId",
                schema: "Iden",
                table: "PersonaME");

            migrationBuilder.RenameColumn(
                name: "DocumentoId",
                schema: "Iden",
                table: "TipoDocumentoME",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                newName: "TipoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_PersonaME_TipoDocumentoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                newName: "IX_PersonaME_TipoDocumentoId");

            migrationBuilder.RenameColumn(
                name: "TipoDocumentoDocumentoId",
                table: "AspNetUsers",
                newName: "TipoDocumentoId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_TipoDocumentoDocumentoId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_TipoDocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TipoDocumentoME_TipoDocumentoId",
                table: "AspNetUsers",
                column: "TipoDocumentoId",
                principalSchema: "Iden",
                principalTable: "TipoDocumentoME",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonaME_TipoDocumentoME_TipoDocumentoId",
                schema: "Iden",
                table: "PersonaME",
                column: "TipoDocumentoId",
                principalSchema: "Iden",
                principalTable: "TipoDocumentoME",
                principalColumn: "Id");
        }
    }
}
