using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Estadios.Migrations
{
    /// <inheritdoc />
    public partial class EquiposVisitantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipoLocal_Partidos_PartidoId",
                table: "EquipoLocal");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipoLocal",
                table: "EquipoLocal");

            migrationBuilder.RenameTable(
                name: "EquipoLocal",
                newName: "EquiposLocales");

            migrationBuilder.RenameIndex(
                name: "IX_EquipoLocal_PartidoId",
                table: "EquiposLocales",
                newName: "IX_EquiposLocales_PartidoId");

            migrationBuilder.AlterColumn<string>(
                name: "Hora",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ubicacion",
                table: "Estadios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Estadios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEquipoL",
                table: "EquiposLocales",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquiposLocales",
                table: "EquiposLocales",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EquiposVisitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEquipoV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CiudadVisitante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartidoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquiposVisitantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquiposVisitantes_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquiposVisitantes_PartidoId",
                table: "EquiposVisitantes",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_EquiposLocales_Partidos_PartidoId",
                table: "EquiposLocales",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquiposLocales_Partidos_PartidoId",
                table: "EquiposLocales");

            migrationBuilder.DropTable(
                name: "EquiposVisitantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquiposLocales",
                table: "EquiposLocales");

            migrationBuilder.RenameTable(
                name: "EquiposLocales",
                newName: "EquipoLocal");

            migrationBuilder.RenameIndex(
                name: "IX_EquiposLocales_PartidoId",
                table: "EquipoLocal",
                newName: "IX_EquipoLocal_PartidoId");

            migrationBuilder.AlterColumn<string>(
                name: "Hora",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Partidos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ubicacion",
                table: "Estadios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Estadios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NombreEquipoL",
                table: "EquipoLocal",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipoLocal",
                table: "EquipoLocal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipoLocal_Partidos_PartidoId",
                table: "EquipoLocal",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
