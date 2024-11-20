using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class AjouterDesignationEtCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "DetailAchatsDirects");

            migrationBuilder.AddColumn<int>(
                name: "ProduitServiceId",
                table: "DetailChiffreAffaire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatierePremiereApprovisionnement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatierePremiereApprovisionnement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduitService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitService", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_ProduitServiceId",
                table: "DetailChiffreAffaire",
                column: "ProduitServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects",
                column: "MatierePremiereApprovisionnementId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAchatsDirects_MatierePremiereApprovisionnement_MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects",
                column: "MatierePremiereApprovisionnementId",
                principalTable: "MatierePremiereApprovisionnement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailChiffreAffaire_ProduitService_ProduitServiceId",
                table: "DetailChiffreAffaire",
                column: "ProduitServiceId",
                principalTable: "ProduitService",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailAchatsDirects_MatierePremiereApprovisionnement_MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailChiffreAffaire_ProduitService_ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropTable(
                name: "MatierePremiereApprovisionnement");

            migrationBuilder.DropTable(
                name: "ProduitService");

            migrationBuilder.DropIndex(
                name: "IX_DetailChiffreAffaire_ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropIndex(
                name: "IX_DetailAchatsDirects_MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropColumn(
                name: "ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropColumn(
                name: "MatierePremiereApprovisionnementId",
                table: "DetailAchatsDirects");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "DetailChiffreAffaire",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "DetailAchatsDirects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
