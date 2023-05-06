using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jardin.Migrations
{
    /// <inheritdoc />
    public partial class patate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aliment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sucre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vitamine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aliment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jardins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Emplacement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surface = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jardins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlimentJardins",
                columns: table => new
                {
                    AlimentId = table.Column<int>(type: "int", nullable: false),
                    JardinsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlimentJardins", x => new { x.AlimentId, x.JardinsId });
                    table.ForeignKey(
                        name: "FK_AlimentJardins_Aliment_AlimentId",
                        column: x => x.AlimentId,
                        principalTable: "Aliment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlimentJardins_Jardins_JardinsId",
                        column: x => x.JardinsId,
                        principalTable: "Jardins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlimentJardins_JardinsId",
                table: "AlimentJardins",
                column: "JardinsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlimentJardins");

            migrationBuilder.DropTable(
                name: "Aliment");

            migrationBuilder.DropTable(
                name: "Jardins");
        }
    }
}
