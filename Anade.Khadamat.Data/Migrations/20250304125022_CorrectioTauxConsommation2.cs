using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class CorrectioTauxConsommation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailTauxConsommation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxConsommation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailTauxConsommation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailTauxConsommation_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailTauxConsommation_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailTauxConsommation_AnneeId",
                table: "DetailTauxConsommation",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailTauxConsommation_BusinessPlanId",
                table: "DetailTauxConsommation",
                column: "BusinessPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailTauxConsommation");
        }
    }
}
