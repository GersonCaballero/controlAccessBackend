using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddZonas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Avenidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avenidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avenidas_Residencial_ResidencialId",
                        column: x => x.ResidencialId,
                        principalTable: "Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloque",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloque", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloque_Residencial_ResidencialId",
                        column: x => x.ResidencialId,
                        principalTable: "Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Calles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calles_Residencial_ResidencialId",
                        column: x => x.ResidencialId,
                        principalTable: "Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Casas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Casas_Residencial_ResidencialId",
                        column: x => x.ResidencialId,
                        principalTable: "Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zonas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ResidencialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zonas_Residencial_ResidencialId",
                        column: x => x.ResidencialId,
                        principalTable: "Residencial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avenidas_ResidencialId",
                table: "Avenidas",
                column: "ResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloque_ResidencialId",
                table: "Bloque",
                column: "ResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Calles_ResidencialId",
                table: "Calles",
                column: "ResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Casas_ResidencialId",
                table: "Casas",
                column: "ResidencialId");

            migrationBuilder.CreateIndex(
                name: "IX_Zonas_ResidencialId",
                table: "Zonas",
                column: "ResidencialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avenidas");

            migrationBuilder.DropTable(
                name: "Bloque");

            migrationBuilder.DropTable(
                name: "Calles");

            migrationBuilder.DropTable(
                name: "Casas");

            migrationBuilder.DropTable(
                name: "Zonas");
        }
    }
}
