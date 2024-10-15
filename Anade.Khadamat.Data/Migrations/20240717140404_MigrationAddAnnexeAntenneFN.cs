using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class MigrationAddAnnexeAntenneFN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomAnnexe",
                table: "FicheNotation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomAntenne",
                table: "FicheNotation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomAnnexe",
                table: "FicheNotation");

            migrationBuilder.DropColumn(
                name: "NomAntenne",
                table: "FicheNotation");
        }
    }
}
