using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class AjouterBasculeRegimeImposition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BasculeRegimeImposition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasculeRegimeImposition", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompteResultatPrevisionnel_BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel",
                column: "BasculeRegimeImpositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompteResultatPrevisionnel_BasculeRegimeImposition_BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel",
                column: "BasculeRegimeImpositionId",
                principalTable: "BasculeRegimeImposition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompteResultatPrevisionnel_BasculeRegimeImposition_BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel");

            migrationBuilder.DropTable(
                name: "BasculeRegimeImposition");

            migrationBuilder.DropIndex(
                name: "IX_CompteResultatPrevisionnel_BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel");

            migrationBuilder.DropColumn(
                name: "BasculeRegimeImpositionId",
                table: "CompteResultatPrevisionnel");
        }
    }
}
