using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorTest.Server.Migrations
{
    public partial class veterinarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veterinarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tarjetaProfessional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veterinarios", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Veterinarios",
                columns: new[] { "Id", "Apellidos", "Nombres", "Telefono", "tarjetaProfessional" },
                values: new object[] { 1, "Perez", "Pepito", "+573158880482", "123456" });

            migrationBuilder.InsertData(
                table: "Veterinarios",
                columns: new[] { "Id", "Apellidos", "Nombres", "Telefono", "tarjetaProfessional" },
                values: new object[] { 2, "Gomez", "Juan", "+573168880482", "953456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veterinarios");
        }
    }
}
