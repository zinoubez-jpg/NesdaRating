using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class Ajouter_TauxConsommation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA1",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA2",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA3",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA4",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA5",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA6",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TauxConsommationA7",
                table: "MatierePremiereApprovisionnement",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TauxConsommationA1",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA2",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA3",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA4",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA5",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA6",
                table: "MatierePremiereApprovisionnement");

            migrationBuilder.DropColumn(
                name: "TauxConsommationA7",
                table: "MatierePremiereApprovisionnement");
        }
    }
}
