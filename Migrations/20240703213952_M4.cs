using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_ResidencialId",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "ResidencialId",
                table: "Casas");

            migrationBuilder.AlterColumn<int>(
                name: "IdZona",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas",
                column: "IdZona",
                principalTable: "Zonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas");

            migrationBuilder.AlterColumn<int>(
                name: "IdZona",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ResidencialId",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Casas_ResidencialId",
                table: "Casas",
                column: "ResidencialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas",
                column: "IdZona",
                principalTable: "Zonas",
                principalColumn: "Id");
        }
    }
}
