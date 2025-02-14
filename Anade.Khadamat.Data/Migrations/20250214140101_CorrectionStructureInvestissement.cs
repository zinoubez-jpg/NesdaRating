using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class CorrectionStructureInvestissement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ApportPersonnel",
                table: "StuctureInvestissement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ApportSupplementaire",
                table: "StuctureInvestissement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CMT",
                table: "StuctureInvestissement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PNRClassique",
                table: "StuctureInvestissement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PNRSupplementaire",
                table: "StuctureInvestissement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApportPersonnel",
                table: "StuctureInvestissement");

            migrationBuilder.DropColumn(
                name: "ApportSupplementaire",
                table: "StuctureInvestissement");

            migrationBuilder.DropColumn(
                name: "CMT",
                table: "StuctureInvestissement");

            migrationBuilder.DropColumn(
                name: "PNRClassique",
                table: "StuctureInvestissement");

            migrationBuilder.DropColumn(
                name: "PNRSupplementaire",
                table: "StuctureInvestissement");
        }
    }
}
