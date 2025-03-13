using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class CorrectioTauxConsommation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailTauxConsommation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailTauxConsommation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    MatierePremiereApprovisionnementId = table.Column<int>(type: "int", nullable: false),
                    TauxConsommation = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                        name: "FK_DetailTauxConsommation_MatierePremiereApprovisionnement_MatierePremiereApprovisionnementId",
                        column: x => x.MatierePremiereApprovisionnementId,
                        principalTable: "MatierePremiereApprovisionnement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailTauxConsommation_AnneeId",
                table: "DetailTauxConsommation",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailTauxConsommation_MatierePremiereApprovisionnementId",
                table: "DetailTauxConsommation",
                column: "MatierePremiereApprovisionnementId");
        }
    }
}
