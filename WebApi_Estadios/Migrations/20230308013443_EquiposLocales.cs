using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Estadios.Migrations
{
    /// <inheritdoc />
    public partial class EquiposLocales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipoLocal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipoL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CiudadLocal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipoLocal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipoLocal_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipoLocal_PartidoId",
                table: "EquipoLocal",
                column: "PartidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipoLocal");
        }
    }
}
