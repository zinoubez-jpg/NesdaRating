using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Anade.Khadamat.Data.Migrations
{
    public partial class AjouterBusinessPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Annee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcquisitionId = table.Column<int>(type: "int", nullable: false),
                    DetailChiffreAffaireId = table.Column<int>(type: "int", nullable: false),
                    DetailAchatsDirectsId = table.Column<int>(type: "int", nullable: false),
                    DetailChargesExternesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Annee", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "BusinessPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Complet = table.Column<bool>(type: "bit", nullable: false),
                    Date_Generation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Utilisateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroSIEJE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
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
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiffereEmprunt",
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
                    table.PrimaryKey("PK_DiffereEmprunt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExonerationFiscale",
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
                    table.PrimaryKey("PK_ExonerationFiscale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormeJuridique",
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
                    table.PrimaryKey("PK_FormeJuridique", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrequenceActivite",
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
                    table.PrimaryKey("PK_FrequenceActivite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProduitService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegimeImposition",
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
                    table.PrimaryKey("PK_RegimeImposition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RubriqueChargesExternes",
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
                    table.PrimaryKey("PK_RubriqueChargesExternes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TauxStructureFinancement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApportPersonnel = table.Column<int>(type: "int", nullable: false),
                    CMT = table.Column<int>(type: "int", nullable: false),
                    PNRClassique = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TauxStructureFinancement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TauxTVA",
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
                    table.PrimaryKey("PK_TauxTVA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeActivite",
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
                    table.PrimaryKey("PK_TypeActivite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFinancement",
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
                    table.PrimaryKey("PK_TypeFinancement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMateriel",
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
                    table.PrimaryKey("PK_TypeMateriel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeZone",
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
                    table.PrimaryKey("PK_TypeZone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WilayaBP",
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
                    table.PrimaryKey("PK_WilayaBP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnneeId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mois_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompteResultatPrevisionnel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChiffreAffaires = table.Column<float>(type: "real", nullable: false),
                    AchatsConsommes = table.Column<float>(type: "real", nullable: false),
                    ChargesExternes = table.Column<float>(type: "real", nullable: false),
                    ValeurAjoutee = table.Column<float>(type: "real", nullable: false),
                    SalairesChargesSociales = table.Column<float>(type: "real", nullable: false),
                    ExcedentBrutExploitation = table.Column<float>(type: "real", nullable: false),
                    AmortissementsProvisions = table.Column<float>(type: "real", nullable: false),
                    ResultatExploitation = table.Column<float>(type: "real", nullable: false),
                    IBS_IFU_IRG = table.Column<float>(type: "real", nullable: false),
                    ResultatNet = table.Column<float>(type: "real", nullable: false),
                    EvolutionChiffreAffaires = table.Column<float>(type: "real", nullable: false),
                    TauxVA = table.Column<float>(type: "real", nullable: false),
                    TauxEBE = table.Column<float>(type: "real", nullable: false),
                    CAF = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteResultatPrevisionnel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompteResultatPrevisionnel_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompteResultatPrevisionnel_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationProjet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontantValeurActuelleNette = table.Column<float>(type: "real", nullable: false),
                    DelaiRecuperation = table.Column<int>(type: "int", nullable: false),
                    InvestissementInitial = table.Column<float>(type: "real", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationProjet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationProjet_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StuctureInvestissement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterielProduction = table.Column<float>(type: "real", nullable: false),
                    MaterielBureau = table.Column<float>(type: "real", nullable: false),
                    MaterielInformatique = table.Column<float>(type: "real", nullable: false),
                    MaterielAudioVisuel = table.Column<float>(type: "real", nullable: false),
                    MaterielCommunication = table.Column<float>(type: "real", nullable: false),
                    InstallationsEquipements = table.Column<float>(type: "real", nullable: false),
                    EquipementsImportes = table.Column<float>(type: "real", nullable: false),
                    ActifsBiologique = table.Column<float>(type: "real", nullable: false),
                    Amenagement = table.Column<float>(type: "real", nullable: false),
                    MaterielRoulant = table.Column<float>(type: "real", nullable: false),
                    FraisGeneraux = table.Column<float>(type: "real", nullable: false),
                    AssurancesLieesCreation = table.Column<float>(type: "real", nullable: false),
                    FondsGarantie = table.Column<float>(type: "real", nullable: false),
                    FondsRoulement = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuctureInvestissement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StuctureInvestissement_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableauFluxTresorerie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncaissementsRecuClients = table.Column<float>(type: "real", nullable: false),
                    SommesVerseesFournisseurs = table.Column<float>(type: "real", nullable: false),
                    SommesVerseesPrestataires = table.Column<float>(type: "real", nullable: false),
                    SommesVerseesPersonnelCNAS_IRG = table.Column<float>(type: "real", nullable: false),
                    DecaissementTVAPayer = table.Column<float>(type: "real", nullable: false),
                    DecaissementIBS_IFU_IRG = table.Column<float>(type: "real", nullable: false),
                    FluxTresorerieProvenantExploitation = table.Column<float>(type: "real", nullable: false),
                    DecaissementAcquisitionEquipements = table.Column<float>(type: "real", nullable: false),
                    FluxTresorerieProvenantInvestissement = table.Column<float>(type: "real", nullable: false),
                    EncaissementsSuiteApportPersonnel = table.Column<float>(type: "real", nullable: false),
                    EncaissementsProvenantEmprunts = table.Column<float>(type: "real", nullable: false),
                    RemboursementsEmpruntsCMT = table.Column<float>(type: "real", nullable: false),
                    RemboursementsEmpruntsPNR = table.Column<float>(type: "real", nullable: false),
                    FluxTresorerieProvenantFinancement = table.Column<float>(type: "real", nullable: false),
                    FluxTresorerieNet = table.Column<float>(type: "real", nullable: false),
                    SoldeInitial = table.Column<float>(type: "real", nullable: false),
                    SoldeFinal = table.Column<float>(type: "real", nullable: false),
                    Equilibre = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableauFluxTresorerie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TableauFluxTresorerie_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableauFluxTresorerie_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailAchatsDirects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<float>(type: "real", nullable: false),
                    PrixUnitaire = table.Column<float>(type: "real", nullable: false),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    ProduitServiceId = table.Column<int>(type: "int", nullable: false),
                    ApprovisionnementMatierePremiereId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailAchatsDirects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailAchatsDirects_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailAchatsDirects_ApprovisionnementMatierePremiere_ApprovisionnementMatierePremiereId",
                        column: x => x.ApprovisionnementMatierePremiereId,
                        principalTable: "ApprovisionnementMatierePremiere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetailAchatsDirects_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailAchatsDirects_ProduitService_ProduitServiceId",
                        column: x => x.ProduitServiceId,
                        principalTable: "ProduitService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailChiffreAffaire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantite = table.Column<float>(type: "real", nullable: false),
                    PrixUnitaire = table.Column<float>(type: "real", nullable: false),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    ProduitServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailChiffreAffaire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailChiffreAffaire_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailChiffreAffaire_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailChiffreAffaire_ProduitService_ProduitServiceId",
                        column: x => x.ProduitServiceId,
                        principalTable: "ProduitService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailChargesExternes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    RubriqueChargesExternesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailChargesExternes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailChargesExternes_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailChargesExternes_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailChargesExternes_RubriqueChargesExternes_RubriqueChargesExternesId",
                        column: x => x.RubriqueChargesExternesId,
                        principalTable: "RubriqueChargesExternes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StructureFinancement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApportPersonnel = table.Column<float>(type: "real", nullable: false),
                    CMT = table.Column<float>(type: "real", nullable: false),
                    PNRClassique = table.Column<float>(type: "real", nullable: false),
                    PNRSupplementaire = table.Column<float>(type: "real", nullable: false),
                    ApportSupplementaire = table.Column<float>(type: "real", nullable: false),
                    TauxIFU = table.Column<float>(type: "real", nullable: false),
                    TauxIBS = table.Column<float>(type: "real", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    DiffereEmpruntId = table.Column<int>(type: "int", nullable: false),
                    ExonerationFiscaleId = table.Column<int>(type: "int", nullable: false),
                    TauxStructureFinancementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructureFinancement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StructureFinancement_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StructureFinancement_DiffereEmprunt_DiffereEmpruntId",
                        column: x => x.DiffereEmpruntId,
                        principalTable: "DiffereEmprunt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StructureFinancement_ExonerationFiscale_ExonerationFiscaleId",
                        column: x => x.ExonerationFiscaleId,
                        principalTable: "ExonerationFiscale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StructureFinancement_TauxStructureFinancement_TauxStructureFinancementId",
                        column: x => x.TauxStructureFinancementId,
                        principalTable: "TauxStructureFinancement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailInvestissement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationMateriel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DureeAmortissement = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    TypeMaterielId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailInvestissement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailInvestissement_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailInvestissement_TypeMateriel_TypeMaterielId",
                        column: x => x.TypeMaterielId,
                        principalTable: "TypeMateriel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommuneBP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZonePromouvoir = table.Column<bool>(type: "bit", nullable: false),
                    WilayaBPId = table.Column<int>(type: "int", nullable: false),
                    TypeZoneId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DesignationFr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    DesignationAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommuneBP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommuneBP_TypeZone_TypeZoneId",
                        column: x => x.TypeZoneId,
                        principalTable: "TypeZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommuneBP_WilayaBP_WilayaBPId",
                        column: x => x.WilayaBPId,
                        principalTable: "WilayaBP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanTresorerieMensuel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldeInitial = table.Column<float>(type: "real", nullable: false),
                    ApportSupplementaire = table.Column<float>(type: "real", nullable: false),
                    CMT = table.Column<float>(type: "real", nullable: false),
                    PNRClassique = table.Column<float>(type: "real", nullable: false),
                    ApportPersonnel = table.Column<float>(type: "real", nullable: false),
                    PNRLoyer = table.Column<float>(type: "real", nullable: false),
                    EncaissementRecusClients = table.Column<float>(type: "real", nullable: false),
                    TotalRecette = table.Column<float>(type: "real", nullable: false),
                    AcquisitionEquipementAmenagement = table.Column<float>(type: "real", nullable: false),
                    DecaissementFournisseurs = table.Column<float>(type: "real", nullable: false),
                    DecaissementPrestataires = table.Column<float>(type: "real", nullable: false),
                    PaiementFGAssurancesFraisLieesCreation = table.Column<float>(type: "real", nullable: false),
                    DecaissementSalairesNets = table.Column<float>(type: "real", nullable: false),
                    CotisationsSociales = table.Column<float>(type: "real", nullable: false),
                    IRGSalaires = table.Column<float>(type: "real", nullable: false),
                    TVAPayer = table.Column<float>(type: "real", nullable: false),
                    IBS_IFU = table.Column<float>(type: "real", nullable: false),
                    TotalDepense = table.Column<float>(type: "real", nullable: false),
                    SoldeFinal = table.Column<float>(type: "real", nullable: false),
                    MoisId = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanTresorerieMensuel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanTresorerieMensuel_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanTresorerieMensuel_Mois_MoisId",
                        column: x => x.MoisId,
                        principalTable: "Mois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailEvaluationProjet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MontantTresorerieNet = table.Column<float>(type: "real", nullable: false),
                    MontantCashFlowActualises = table.Column<float>(type: "real", nullable: false),
                    MontantCumulCFActualises = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    EvaluationProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailEvaluationProjet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailEvaluationProjet_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailEvaluationProjet_EvaluationProjet_EvaluationProjetId",
                        column: x => x.EvaluationProjetId,
                        principalTable: "EvaluationProjet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Acquisition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<float>(type: "real", nullable: false),
                    AnneeId = table.Column<int>(type: "int", nullable: false),
                    DetailInvestissementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acquisition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acquisition_Annee_AnneeId",
                        column: x => x.AnneeId,
                        principalTable: "Annee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Acquisition_DetailInvestissement_DetailInvestissementId",
                        column: x => x.DetailInvestissementId,
                        principalTable: "DetailInvestissement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoutProjet = table.Column<float>(type: "real", nullable: false),
                    SoumisImposition = table.Column<bool>(type: "bit", nullable: false),
                    ExonerationTVA = table.Column<bool>(type: "bit", nullable: false),
                    DelaiClient = table.Column<int>(type: "int", nullable: false),
                    DelaiFournisseur = table.Column<int>(type: "int", nullable: false),
                    DelaiPrestataire = table.Column<int>(type: "int", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false),
                    TauxTVAId = table.Column<int>(type: "int", nullable: false),
                    CategorieId = table.Column<int>(type: "int", nullable: false),
                    CommuneBPId = table.Column<int>(type: "int", nullable: false),
                    TypeFinancementId = table.Column<int>(type: "int", nullable: false),
                    FormeJuridiqueId = table.Column<int>(type: "int", nullable: false),
                    RegimeImpositionId = table.Column<int>(type: "int", nullable: false),
                    TypeActiviteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationBase_BusinessPlan_BusinessPlanId",
                        column: x => x.BusinessPlanId,
                        principalTable: "BusinessPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_CommuneBP_CommuneBPId",
                        column: x => x.CommuneBPId,
                        principalTable: "CommuneBP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_FormeJuridique_FormeJuridiqueId",
                        column: x => x.FormeJuridiqueId,
                        principalTable: "FormeJuridique",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_RegimeImposition_RegimeImpositionId",
                        column: x => x.RegimeImpositionId,
                        principalTable: "RegimeImposition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_TauxTVA_TauxTVAId",
                        column: x => x.TauxTVAId,
                        principalTable: "TauxTVA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_TypeActivite_TypeActiviteId",
                        column: x => x.TypeActiviteId,
                        principalTable: "TypeActivite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationBase_TypeFinancement_TypeFinancementId",
                        column: x => x.TypeFinancementId,
                        principalTable: "TypeFinancement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailActiviteMois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TauxActivite = table.Column<float>(type: "real", nullable: false),
                    MoisId = table.Column<int>(type: "int", nullable: false),
                    FrequenceActiviteId = table.Column<int>(type: "int", nullable: false),
                    InformationBaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailActiviteMois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailActiviteMois_FrequenceActivite_FrequenceActiviteId",
                        column: x => x.FrequenceActiviteId,
                        principalTable: "FrequenceActivite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailActiviteMois_InformationBase_InformationBaseId",
                        column: x => x.InformationBaseId,
                        principalTable: "InformationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailActiviteMois_Mois_MoisId",
                        column: x => x.MoisId,
                        principalTable: "Mois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_AnneeId",
                table: "Acquisition",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Acquisition_DetailInvestissementId",
                table: "Acquisition",
                column: "DetailInvestissementId");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneBP_TypeZoneId",
                table: "CommuneBP",
                column: "TypeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CommuneBP_WilayaBPId",
                table: "CommuneBP",
                column: "WilayaBPId");

            migrationBuilder.CreateIndex(
                name: "IX_CompteResultatPrevisionnel_AnneeId",
                table: "CompteResultatPrevisionnel",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_CompteResultatPrevisionnel_BusinessPlanId",
                table: "CompteResultatPrevisionnel",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_AnneeId",
                table: "DetailAchatsDirects",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_ApprovisionnementMatierePremiereId",
                table: "DetailAchatsDirects",
                column: "ApprovisionnementMatierePremiereId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_BusinessPlanId",
                table: "DetailAchatsDirects",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailAchatsDirects_ProduitServiceId",
                table: "DetailAchatsDirects",
                column: "ProduitServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailActiviteMois_FrequenceActiviteId",
                table: "DetailActiviteMois",
                column: "FrequenceActiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailActiviteMois_InformationBaseId",
                table: "DetailActiviteMois",
                column: "InformationBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailActiviteMois_MoisId",
                table: "DetailActiviteMois",
                column: "MoisId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChargesExternes_AnneeId",
                table: "DetailChargesExternes",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailChargesExternes_BusinessPlanId",
                table: "DetailChargesExternes",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChargesExternes_RubriqueChargesExternesId",
                table: "DetailChargesExternes",
                column: "RubriqueChargesExternesId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_AnneeId",
                table: "DetailChiffreAffaire",
                column: "AnneeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_BusinessPlanId",
                table: "DetailChiffreAffaire",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailChiffreAffaire_ProduitServiceId",
                table: "DetailChiffreAffaire",
                column: "ProduitServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailEvaluationProjet_AnneeId",
                table: "DetailEvaluationProjet",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailEvaluationProjet_EvaluationProjetId",
                table: "DetailEvaluationProjet",
                column: "EvaluationProjetId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailInvestissement_BusinessPlanId",
                table: "DetailInvestissement",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailInvestissement_TypeMaterielId",
                table: "DetailInvestissement",
                column: "TypeMaterielId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationProjet_BusinessPlanId",
                table: "EvaluationProjet",
                column: "BusinessPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_BusinessPlanId",
                table: "InformationBase",
                column: "BusinessPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_CategorieId",
                table: "InformationBase",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_CommuneBPId",
                table: "InformationBase",
                column: "CommuneBPId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_FormeJuridiqueId",
                table: "InformationBase",
                column: "FormeJuridiqueId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_RegimeImpositionId",
                table: "InformationBase",
                column: "RegimeImpositionId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_TauxTVAId",
                table: "InformationBase",
                column: "TauxTVAId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_TypeActiviteId",
                table: "InformationBase",
                column: "TypeActiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationBase_TypeFinancementId",
                table: "InformationBase",
                column: "TypeFinancementId");

            migrationBuilder.CreateIndex(
                name: "IX_Mois_AnneeId",
                table: "Mois",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanTresorerieMensuel_BusinessPlanId",
                table: "PlanTresorerieMensuel",
                column: "BusinessPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanTresorerieMensuel_MoisId",
                table: "PlanTresorerieMensuel",
                column: "MoisId");

            migrationBuilder.CreateIndex(
                name: "IX_StructureFinancement_BusinessPlanId",
                table: "StructureFinancement",
                column: "BusinessPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StructureFinancement_DiffereEmpruntId",
                table: "StructureFinancement",
                column: "DiffereEmpruntId");

            migrationBuilder.CreateIndex(
                name: "IX_StructureFinancement_ExonerationFiscaleId",
                table: "StructureFinancement",
                column: "ExonerationFiscaleId");

            migrationBuilder.CreateIndex(
                name: "IX_StructureFinancement_TauxStructureFinancementId",
                table: "StructureFinancement",
                column: "TauxStructureFinancementId");

            migrationBuilder.CreateIndex(
                name: "IX_StuctureInvestissement_BusinessPlanId",
                table: "StuctureInvestissement",
                column: "BusinessPlanId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableauFluxTresorerie_AnneeId",
                table: "TableauFluxTresorerie",
                column: "AnneeId");

            migrationBuilder.CreateIndex(
                name: "IX_TableauFluxTresorerie_BusinessPlanId",
                table: "TableauFluxTresorerie",
                column: "BusinessPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acquisition");

            migrationBuilder.DropTable(
                name: "CompteResultatPrevisionnel");

            migrationBuilder.DropTable(
                name: "DetailAchatsDirects");

            migrationBuilder.DropTable(
                name: "DetailActiviteMois");

            migrationBuilder.DropTable(
                name: "DetailChargesExternes");

            migrationBuilder.DropTable(
                name: "DetailChiffreAffaire");

            migrationBuilder.DropTable(
                name: "DetailEvaluationProjet");

            migrationBuilder.DropTable(
                name: "PlanTresorerieMensuel");

            migrationBuilder.DropTable(
                name: "StructureFinancement");

            migrationBuilder.DropTable(
                name: "StuctureInvestissement");

            migrationBuilder.DropTable(
                name: "TableauFluxTresorerie");

            migrationBuilder.DropTable(
                name: "DetailInvestissement");

            migrationBuilder.DropTable(
                name: "ApprovisionnementMatierePremiere");

            migrationBuilder.DropTable(
                name: "FrequenceActivite");

            migrationBuilder.DropTable(
                name: "InformationBase");

            migrationBuilder.DropTable(
                name: "RubriqueChargesExternes");

            migrationBuilder.DropTable(
                name: "ProduitService");

            migrationBuilder.DropTable(
                name: "EvaluationProjet");

            migrationBuilder.DropTable(
                name: "Mois");

            migrationBuilder.DropTable(
                name: "DiffereEmprunt");

            migrationBuilder.DropTable(
                name: "ExonerationFiscale");

            migrationBuilder.DropTable(
                name: "TauxStructureFinancement");

            migrationBuilder.DropTable(
                name: "TypeMateriel");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "CommuneBP");

            migrationBuilder.DropTable(
                name: "FormeJuridique");

            migrationBuilder.DropTable(
                name: "RegimeImposition");

            migrationBuilder.DropTable(
                name: "TauxTVA");

            migrationBuilder.DropTable(
                name: "TypeActivite");

            migrationBuilder.DropTable(
                name: "TypeFinancement");

            migrationBuilder.DropTable(
                name: "BusinessPlan");

            migrationBuilder.DropTable(
                name: "Annee");

            migrationBuilder.DropTable(
                name: "TypeZone");

            migrationBuilder.DropTable(
                name: "WilayaBP");
        }
    }
}
