using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class ScoreSousTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScoreAutreCritereStrategique",
                table: "FicheNotation",
                newName: "ScoreSousTotal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ScoreSousTotal",
                table: "FicheNotation",
                newName: "ScoreAutreCritereStrategique");
        }
    }
}
