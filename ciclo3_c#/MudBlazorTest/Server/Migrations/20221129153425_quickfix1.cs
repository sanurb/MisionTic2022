using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorTest.Server.Migrations
{
    public partial class quickfix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tarjetaProfessional",
                table: "Veterinarios",
                newName: "TarjetaProfesional");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TarjetaProfesional",
                table: "Veterinarios",
                newName: "tarjetaProfessional");
        }
    }
}
