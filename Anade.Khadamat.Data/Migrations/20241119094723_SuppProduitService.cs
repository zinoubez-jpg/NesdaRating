using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class SuppProduitService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailAchatsDirects_ProduitService_ProduitServiceId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailChiffreAffaire_ProduitService_ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropTable(
                name: "ProduitService");

            migrationBuilder.DropIndex(
                name: "IX_DetailChiffreAffaire_ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropIndex(
                name: "IX_DetailAchatsDirects_ProduitServiceId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropColumn(
                name: "ProduitServiceId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropColumn(
                name: "ProduitServiceId",
                table: "DetailAchatsDirects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProduitServiceId",
                table: "DetailChiffreAffaire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProduitServiceId",
                table: "DetailAchatsDirects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProduitService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "IX_DetailAchatsDirects_ProduitServiceId",
                table: "DetailAchatsDirects",
                column: "ProduitServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAchatsDirects_ProduitService_ProduitServiceId",
                table: "DetailAchatsDirects",
                column: "ProduitServiceId",
                principalTable: "ProduitService",
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
    }
}
