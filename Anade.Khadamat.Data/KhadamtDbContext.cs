using Anade.Khadamat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Anade.Khadamat.Data
{
    public class KhadamtDbContext : DbContext
    {
        public KhadamtDbContext() : base()
        {

        }

        public KhadamtDbContext(DbContextOptions<KhadamtDbContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\serverDB;Database=KhadamatDB;Integrated Security=true;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<NiveauFormation> NiveauFormations { get; set; }
        public virtual DbSet<ExperienceProfessionnel> ExperienceProfessionnels { get; set; }
        public virtual DbSet<Van> Vans { get; set; }
        public virtual DbSet<Dr> Drs { get; set; }
        public virtual DbSet<Pricing> Pricings { get; set; }
        public virtual DbSet<Marketing> Marketings { get; set; }
        public virtual DbSet<ContributionFinanciere> ContributionFinancieres { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Concorrdence> Concorrdences { get; set; }


        // Dbset Business Plan
        public virtual DbSet<Acquisition> Acquisition { get; set; }
        public virtual DbSet<Annee> Annee { get; set; }
        public virtual DbSet<ApprovisionnementMatierePremiere> ApprovisionnementMatierePremiere { get; set; }
        public virtual DbSet<BusinessPlan> BusinessPlan { get; set; }
        public virtual DbSet<CompteResultatPrevisionnel> CompteResultatPrevisionnel { get; set; }
        public virtual DbSet<DetailAchatsDirects> DetailAchatsDirects { get; set; }
        public virtual DbSet<DetailChargesExternes> DetailChargesExternes { get; set; }
        public virtual DbSet<DetailChiffreAffaire> DetailChiffreAffaire { get; set; }
        public virtual DbSet<DetailEvaluationProjet> DetailEvaluationProjet { get; set; }
        public virtual DbSet<DetailInvestissement> DetailInvestissement { get; set; }
        public virtual DbSet<EvaluationProjet> EvaluationProjet { get; set; }
        public virtual DbSet<Mois> Mois { get; set; }
        public virtual DbSet<PlanTresorerieMensuel> PlanTresorerieMensuel { get; set; }
        public virtual DbSet<ProduitService> ProduitService { get; set; }
        public virtual DbSet<Projet> Projet { get; set; }
        public virtual DbSet<RubriqueChargesExternes> RubriqueChargesExternes { get; set; }
        public virtual DbSet<RubriqueStuctureInvestissement> RubriqueStuctureInvestissement { get; set; }
        public virtual DbSet<StructureFinancement> StructureFinancement { get; set; }
        public virtual DbSet<StuctureInvestissement> StuctureInvestissement { get; set; }
        public virtual DbSet<TableauFluxTresorerie> TableauFluxTresorerie { get; set; }
        public virtual DbSet<TypeMateriel> TypeMateriel { get; set; }

    }
}
