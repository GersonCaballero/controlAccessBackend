using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class create20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avenidas_Residencial_ResidencialId",
                table: "Avenidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloque_Residencial_ResidencialId",
                table: "Bloque");

            migrationBuilder.DropForeignKey(
                name: "FK_Calles_Residencial_ResidencialId",
                table: "Calles");

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
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Inmuebles_IdTipoInmueble",
                table: "Tarifas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoDeUsuario",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Residencial_ResidencialId",
                table: "Zonas");

            migrationBuilder.AddForeignKey(
                name: "FK_Avenidas_Residencial_ResidencialId",
                table: "Avenidas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bloque_Residencial_ResidencialId",
                table: "Bloque",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Calles_Residencial_ResidencialId",
                table: "Calles",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Inmuebles_IdTipoInmueble",
                table: "Tarifas",
                column: "IdTipoInmueble",
                principalTable: "Inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoDeUsuario",
                table: "Usuarios",
                column: "IdTipoDeUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Residencial_ResidencialId",
                table: "Zonas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avenidas_Residencial_ResidencialId",
                table: "Avenidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bloque_Residencial_ResidencialId",
                table: "Bloque");

            migrationBuilder.DropForeignKey(
                name: "FK_Calles_Residencial_ResidencialId",
                table: "Calles");

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
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Inmuebles_IdTipoInmueble",
                table: "Tarifas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoDeUsuario",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Residencial_ResidencialId",
                table: "Zonas");

            migrationBuilder.AddForeignKey(
                name: "FK_Avenidas_Residencial_ResidencialId",
                table: "Avenidas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bloque_Residencial_ResidencialId",
                table: "Bloque",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calles_Residencial_ResidencialId",
                table: "Calles",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id");

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
                name: "FK_Casas_Residencial_ResidencialId",
                table: "Casas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Inmuebles_IdTipoInmueble",
                table: "Tarifas",
                column: "IdTipoInmueble",
                principalTable: "Inmuebles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoUsuario_IdTipoDeUsuario",
                table: "Usuarios",
                column: "IdTipoDeUsuario",
                principalTable: "TipoUsuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Residencial_ResidencialId",
                table: "Zonas",
                column: "ResidencialId",
                principalTable: "Residencial",
                principalColumn: "Id");
        }
    }
}
