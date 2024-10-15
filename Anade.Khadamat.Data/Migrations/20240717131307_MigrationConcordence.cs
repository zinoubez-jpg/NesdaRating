using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class MigrationConcordence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheNotation_Concorrdences_ConcorrdenceId1",
                table: "FicheNotation");

            migrationBuilder.DropIndex(
                name: "IX_FicheNotation_ConcorrdenceId1",
                table: "FicheNotation");

            migrationBuilder.DropColumn(
                name: "ConcorrdenceId1",
                table: "FicheNotation");

            migrationBuilder.AlterColumn<int>(
                name: "ConcorrdenceId",
                table: "FicheNotation",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ConcorrdenceId",
                table: "FicheNotation",
                column: "ConcorrdenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheNotation_Concorrdences_ConcorrdenceId",
                table: "FicheNotation",
                column: "ConcorrdenceId",
                principalTable: "Concorrdences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheNotation_Concorrdences_ConcorrdenceId",
                table: "FicheNotation");

            migrationBuilder.DropIndex(
                name: "IX_FicheNotation_ConcorrdenceId",
                table: "FicheNotation");

            migrationBuilder.AlterColumn<bool>(
                name: "ConcorrdenceId",
                table: "FicheNotation",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConcorrdenceId1",
                table: "FicheNotation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ConcorrdenceId1",
                table: "FicheNotation",
                column: "ConcorrdenceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheNotation_Concorrdences_ConcorrdenceId1",
                table: "FicheNotation",
                column: "ConcorrdenceId1",
                principalTable: "Concorrdences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
