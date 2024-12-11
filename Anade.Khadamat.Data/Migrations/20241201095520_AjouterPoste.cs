using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class AjouterPoste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Poste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalaireBase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndemnitesPrimesCotisables = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndemnitesPrimesImposables = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SLR_Indemnites_PrimesNonImplCotl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetPayer = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RetenueIRG = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poste", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailPoste",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmploi = table.Column<int>(type: "int", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    PosteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPoste", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailPoste_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailPoste_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailPoste_Poste_PosteId",
                        column: x => x.PosteId,
                        principalTable: "Poste",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailPoste_AnneeId",
                table: "DetailPoste",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPoste_BusinessPlanId",
                table: "DetailPoste",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPoste_PosteId",
                table: "DetailPoste",
                column: "PosteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailPoste");

            migrationBuilder.DropTable(
                name: "Poste");
        }
    }
}
