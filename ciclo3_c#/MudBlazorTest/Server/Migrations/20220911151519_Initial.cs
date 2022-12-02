using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MudBlazorTest.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Propietarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Afiliacion = table.Column<bool>(type: "bit", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropietarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perros_Propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "Propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Propietarios",
                columns: new[] { "Id", "Apellidos", "Direccion", "Nombres", "Telefono" },
                values: new object[] { 1, "Urbano Rivadeneira", "Calle 63# 4-52, Cali, Valle", "David Santiago", "+573158880482" });

            migrationBuilder.InsertData(
                table: "Propietarios",
                columns: new[] { "Id", "Apellidos", "Direccion", "Nombres", "Telefono" },
                values: new object[] { 2, "Urbano Rivadeneira", "Calle 63# 4-52, Cali, Valle", "Sofia", "+573168880482" });

            migrationBuilder.InsertData(
                table: "Perros",
                columns: new[] { "Id", "Afiliacion", "Color", "Nombre", "PropietarioId", "Raza", "Sexo" },
                values: new object[] { 1, true, "Blanco con dorado", "Isis", 1, "Beagle", "Hembra" });

            migrationBuilder.InsertData(
                table: "Perros",
                columns: new[] { "Id", "Afiliacion", "Color", "Nombre", "PropietarioId", "Raza", "Sexo" },
                values: new object[] { 2, false, "Blanco con dorado", "Valentino", 2, "Bulldog", "Macho" });

            migrationBuilder.CreateIndex(
                name: "IX_Perros_PropietarioId",
                table: "Perros",
                column: "PropietarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perros");

            migrationBuilder.DropTable(
                name: "Propietarios");
        }
    }
}
