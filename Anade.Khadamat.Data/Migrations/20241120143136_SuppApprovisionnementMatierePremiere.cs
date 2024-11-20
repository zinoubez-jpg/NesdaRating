using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class SuppApprovisionnementMatierePremiere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailAchatsDirects_ApprovisionnementMatierePremiere_ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropTable(
                name: "ApprovisionnementMatierePremiere");

            migrationBuilder.DropIndex(
                name: "IX_DetailAchatsDirects_ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropColumn(
                name: "ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApprovisionnementMatierePremiere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovisionnementMatierePremiere", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects",
                column: "ApprovisionnementMatierePremiereId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailAchatsDirects_ApprovisionnementMatierePremiere_ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects",
                column: "ApprovisionnementMatierePremiereId",
                principalTable: "ApprovisionnementMatierePremiere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
