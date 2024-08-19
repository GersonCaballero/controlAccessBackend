using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class InsidenciasAccesos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Incidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    CasaId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidencias_Casas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidencias_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reportes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoReporte = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaHoraGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reportes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehiculos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroIdentidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    VisitanteId = table.Column<int>(type: "int", nullable: true),
                    TipoAcceso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: true),
                    CasaId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesos_Casas_CasaId",
                        column: x => x.CasaId,
                        principalTable: "Casas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accesos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accesos_Vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "Vehiculos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accesos_Visitantes_VisitanteId",
                        column: x => x.VisitanteId,
                        principalTable: "Visitantes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_CasaId",
                table: "Accesos",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_UsuarioId",
                table: "Accesos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_VehiculoId",
                table: "Accesos",
                column: "VehiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_VisitanteId",
                table: "Accesos",
                column: "VisitanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_CasaId",
                table: "Incidencias",
                column: "CasaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidencias_UsuarioId",
                table: "Incidencias",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reportes_UsuarioId",
                table: "Reportes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_UsuarioId",
                table: "Vehiculos",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DropTable(
                name: "Incidencias");

            migrationBuilder.DropTable(
                name: "Reportes");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "Visitantes");
        }
    }
}
