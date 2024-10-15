using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antenne",
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
                    table.PrimaryKey("PK_Antenne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concorrdences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concorrdences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContributionFinancieres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContributionFinancieres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceProfessionnels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceProfessionnels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marketings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiveauFormations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveauFormations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pricings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pricings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Annexe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AntenneId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annexe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Annexe_Antenne_AntenneId",
                        column: x => x.AntenneId,
                        principalTable: "Antenne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "FicheNotation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PromoteurId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NOM_P = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PRENOM_P = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DDN_P = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RAISON_SOCIALE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_DEPOT = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NiveauFormationId = table.Column<int>(type: "int", nullable: false),
                    ContributionFinanciereId = table.Column<int>(type: "int", nullable: false),
                    ConcorrdenceId = table.Column<bool>(type: "bit", nullable: false),
                    CapaciteDefendreProjet = table.Column<int>(type: "int", nullable: false),
                    Marche = table.Column<int>(type: "int", nullable: false),
                    Concurrents = table.Column<int>(type: "int", nullable: false),
                    EtudeTechnicoEconomique = table.Column<bool>(type: "bit", nullable: false),
                    CreationEmploi = table.Column<int>(type: "int", nullable: false),
                    ProduitTemoin = table.Column<bool>(type: "bit", nullable: false),
                    Analyste = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    appreciation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoteNiveauFormation = table.Column<int>(type: "int", nullable: false),
                    NoteExperienceprofessionnelle = table.Column<int>(type: "int", nullable: false),
                    NoteConcordance = table.Column<int>(type: "int", nullable: false),
                    NoteContributionFinanciere = table.Column<int>(type: "int", nullable: false),
                    NoteClients = table.Column<int>(type: "int", nullable: false),
                    NoteMarketing = table.Column<int>(type: "int", nullable: false),
                    NotePricing = table.Column<int>(type: "int", nullable: false),
                    NoteEtudeTechnicoEconomique = table.Column<int>(type: "int", nullable: false),
                    NoteVan = table.Column<int>(type: "int", nullable: false),
                    NoteDr = table.Column<int>(type: "int", nullable: false),
                    NoteProduitTemoin = table.Column<int>(type: "int", nullable: false),
                    Deliberation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScorePorteurProjet = table.Column<int>(type: "int", nullable: false),
                    ScoreEtudeMarche = table.Column<int>(type: "int", nullable: false),
                    ScoreBusinessPlan = table.Column<int>(type: "int", nullable: false),
                    ScoreAutreCritereStrategique = table.Column<int>(type: "int", nullable: false),
                    ScoreTotal = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MarketingId = table.Column<int>(type: "int", nullable: false),
                    PricingId = table.Column<int>(type: "int", nullable: false),
                    VanId = table.Column<int>(type: "int", nullable: false),
                    DrId = table.Column<int>(type: "int", nullable: false),
                    ExperienceProfessionnelId = table.Column<int>(type: "int", nullable: false),
                    AnnexeId = table.Column<int>(type: "int", nullable: false),
                    ConcorrdenceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheNotation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Annexe_AnnexeId",
                        column: x => x.AnnexeId,
                        principalTable: "Annexe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Concorrdences_ConcorrdenceId1",
                        column: x => x.ConcorrdenceId1,
                        principalTable: "Concorrdences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FicheNotation_ContributionFinancieres_ContributionFinanciereId",
                        column: x => x.ContributionFinanciereId,
                        principalTable: "ContributionFinancieres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Drs_DrId",
                        column: x => x.DrId,
                        principalTable: "Drs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_ExperienceProfessionnels_ExperienceProfessionnelId",
                        column: x => x.ExperienceProfessionnelId,
                        principalTable: "ExperienceProfessionnels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Marketings_MarketingId",
                        column: x => x.MarketingId,
                        principalTable: "Marketings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_NiveauFormations_NiveauFormationId",
                        column: x => x.NiveauFormationId,
                        principalTable: "NiveauFormations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Pricings_PricingId",
                        column: x => x.PricingId,
                        principalTable: "Pricings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_FicheNotation_Vans_VanId",
                        column: x => x.VanId,
                        principalTable: "Vans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Annexe_AntenneId",
                table: "Annexe",
                column: "AntenneId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_AnnexeId",
                table: "FicheNotation",
                column: "AnnexeId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ClientId",
                table: "FicheNotation",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ConcorrdenceId1",
                table: "FicheNotation",
                column: "ConcorrdenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ContributionFinanciereId",
                table: "FicheNotation",
                column: "ContributionFinanciereId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_DrId",
                table: "FicheNotation",
                column: "DrId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_ExperienceProfessionnelId",
                table: "FicheNotation",
                column: "ExperienceProfessionnelId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_MarketingId",
                table: "FicheNotation",
                column: "MarketingId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_NiveauFormationId",
                table: "FicheNotation",
                column: "NiveauFormationId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_PricingId",
                table: "FicheNotation",
                column: "PricingId");

            migrationBuilder.CreateIndex(
                name: "IX_FicheNotation_VanId",
                table: "FicheNotation",
                column: "VanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FicheNotation");

            migrationBuilder.DropTable(
                name: "Annexe");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Concorrdences");

            migrationBuilder.DropTable(
                name: "ContributionFinancieres");

            migrationBuilder.DropTable(
                name: "Drs");

            migrationBuilder.DropTable(
                name: "ExperienceProfessionnels");

            migrationBuilder.DropTable(
                name: "Marketings");

            migrationBuilder.DropTable(
                name: "NiveauFormations");

            migrationBuilder.DropTable(
                name: "Pricings");

            migrationBuilder.DropTable(
                name: "Vans");

            migrationBuilder.DropTable(
                name: "Antenne");
        }
    }
}
