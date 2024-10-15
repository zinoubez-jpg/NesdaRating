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
        

    }
}
