using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class CorrectionAnnee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailChiffreAffaire_AnneeId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropIndex(
                name: "IX_DetailChargesExternes_AnneeId",
                table: "DetailChargesExternes");

            migrationBuilder.DropIndex(
                name: "IX_DetailAchatsDirects_AnneeId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropIndex(
                name: "IX_Acquisition_AnneeId",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "AcquisitionId",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "DetailAchatsDirectsId",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "DetailChargesExternesId",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "DetailChiffreAffaireId",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Annee");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Annee",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DesignationAr",
                table: "Annee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DesignationFr",
                table: "Annee",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_AnneeId",
                table: "DetailChiffreAffaire",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChargesExternes_AnneeId",
                table: "DetailChargesExternes",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_AnneeId",
                table: "DetailAchatsDirects",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_AnneeId",
                table: "Acquisition",
                column: "AnneeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DetailChiffreAffaire_AnneeId",
                table: "DetailChiffreAffaire");

            migrationBuilder.DropIndex(
                name: "IX_DetailChargesExternes_AnneeId",
                table: "DetailChargesExternes");

            migrationBuilder.DropIndex(
                name: "IX_DetailAchatsDirects_AnneeId",
                table: "DetailAchatsDirects");

            migrationBuilder.DropIndex(
                name: "IX_Acquisition_AnneeId",
                table: "Acquisition");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "DesignationAr",
                table: "Annee");

            migrationBuilder.DropColumn(
                name: "DesignationFr",
                table: "Annee");

            migrationBuilder.AddColumn<int>(
                name: "AcquisitionId",
                table: "Annee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DetailAchatsDirectsId",
                table: "Annee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DetailChargesExternesId",
                table: "Annee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DetailChiffreAffaireId",
                table: "Annee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Annee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_AnneeId",
                table: "DetailChiffreAffaire",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailChargesExternes_AnneeId",
                table: "DetailChargesExternes",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_AnneeId",
                table: "DetailAchatsDirects",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_AnneeId",
                table: "Acquisition",
                column: "AnneeId",
                unique: true);
        }
    }
}
