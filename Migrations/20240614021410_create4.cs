using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class create4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Usuarios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "TipoUsuario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TipoUsuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Inmuebles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCalle",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdBloque",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdAvenida",
                table: "Casas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Avenidas_IdAvenida",
                table: "Casas",
                column: "IdAvenida",
                principalTable: "Avenidas",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Bloque_IdBloque",
                table: "Casas",
                column: "IdBloque",
                principalTable: "Bloque",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Calles_IdCalle",
                table: "Casas",
                column: "IdCalle",
                principalTable: "Calles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "Usuarios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "TipoUsuario",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TipoUsuario",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Inmuebles",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "IdCalle",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdBloque",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IdAvenida",
                table: "Casas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
        }
    }
}
