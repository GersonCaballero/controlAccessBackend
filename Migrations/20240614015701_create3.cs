using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class create3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Zonas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Zonas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Zonas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Zonas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Casas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "IdAvenida",
                table: "Casas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdBloque",
                table: "Casas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdCalle",
                table: "Casas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdZona",
                table: "Casas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Casas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Casas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Calles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Calles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Calles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Calles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Bloque",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Bloque",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Bloque",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Bloque",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Avenidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Avenidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "Avenidas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Avenidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Casas_IdAvenida",
                table: "Casas",
                column: "IdAvenida");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_IdBloque",
                table: "Casas",
                column: "IdBloque");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_IdCalle",
                table: "Casas",
                column: "IdCalle");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_IdZona",
                table: "Casas",
                column: "IdZona");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Avenidas_IdAvenida",
                table: "Casas",
                column: "IdAvenida",
                principalTable: "Avenidas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Bloque_IdBloque",
                table: "Casas",
                column: "IdBloque",
                principalTable: "Bloque",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Calles_IdCalle",
                table: "Casas",
                column: "IdCalle",
                principalTable: "Calles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas",
                column: "IdZona",
                principalTable: "Zonas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Avenidas_IdAvenida",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Bloque_IdBloque",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Calles_IdCalle",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Casas_Zonas_IdZona",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_IdAvenida",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_IdBloque",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_IdCalle",
                table: "Casas");

            migrationBuilder.DropIndex(
                name: "IX_Casas_IdZona",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Zonas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "IdAvenida",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "IdBloque",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "IdCalle",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "IdZona",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Casas");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Calles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Calles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Calles");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Calles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Bloque");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Bloque");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Bloque");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Bloque");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Avenidas");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Avenidas");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Avenidas");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Avenidas");
        }
    }
}
