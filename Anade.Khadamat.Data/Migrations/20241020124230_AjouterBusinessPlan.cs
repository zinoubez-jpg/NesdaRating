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
                name: "Projet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroSIEJE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaisonSociale = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wilaya = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Commune = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormeJuridique = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeFinancement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projet", x => x.Id);
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
                name: "RubriqueStuctureInvestissement",
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
                    table.PrimaryKey("PK_RubriqueStuctureInvestissement", x => x.Id);
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
                name: "BusinessPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_Generation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Complet = table.Column<bool>(type: "bit", nullable: false),
                    Utilisateur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetId = table.Column<int>(type: "int", nullable: false),
                    StuctureInvestissementId = table.Column<int>(type: "int", nullable: false),
                    StructureFinancementId = table.Column<int>(type: "int", nullable: false),
                    EvaluationProjetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessPlan_Projet_ProjetId",
                        column: x => x.ProjetId,
                        principalTable: "Projet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DiffereEmprunt = table.Column<int>(type: "int", nullable: false),
                    ExonerationFiscale = table.Column<float>(type: "real", nullable: false),
                    BusinessPlanId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_BusinessPlan_ProjetId",
                table: "BusinessPlan",
                column: "ProjetId");

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
                name: "DetailChargesExternes");

            migrationBuilder.DropTable(
                name: "DetailChiffreAffaire");

            migrationBuilder.DropTable(
                name: "DetailEvaluationProjet");

            migrationBuilder.DropTable(
                name: "PlanTresorerieMensuel");

            migrationBuilder.DropTable(
                name: "RubriqueStuctureInvestissement");

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
                name: "RubriqueChargesExternes");

            migrationBuilder.DropTable(
                name: "ProduitService");

            migrationBuilder.DropTable(
                name: "EvaluationProjet");

            migrationBuilder.DropTable(
                name: "Mois");

            migrationBuilder.DropTable(
                name: "TypeMateriel");

            migrationBuilder.DropTable(
                name: "BusinessPlan");

            migrationBuilder.DropTable(
                name: "Annee");

            migrationBuilder.DropTable(
                name: "Projet");
        }
    }
}
