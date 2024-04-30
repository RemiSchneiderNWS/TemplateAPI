using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemplateAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_objet",
                table: "objet");

            migrationBuilder.RenameTable(
                name: "objet",
                newName: "Objet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Objet",
                table: "Objet",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Objet",
                table: "Objet");

            migrationBuilder.RenameTable(
                name: "Objet",
                newName: "objet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_objet",
                table: "objet",
                column: "Id");
        }
    }
}
