using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class AjouterEtape : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EtapeId",
                table: "BusinessPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Etape",
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
                    table.PrimaryKey("PK_Etape", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessPlan_EtapeId",
                table: "BusinessPlan",
                column: "EtapeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusinessPlan_Etape_EtapeId",
                table: "BusinessPlan",
                column: "EtapeId",
                principalTable: "Etape",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusinessPlan_Etape_EtapeId",
                table: "BusinessPlan");

            migrationBuilder.DropTable(
                name: "Etape");

            migrationBuilder.DropIndex(
                name: "IX_BusinessPlan_EtapeId",
                table: "BusinessPlan");

            migrationBuilder.DropColumn(
                name: "EtapeId",
                table: "BusinessPlan");
        }
    }
}
