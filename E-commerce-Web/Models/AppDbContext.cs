using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Web.Http.Results;

namespace AGRISmartPro.Models
{
    public class AppDbContext : DbContext
    {      
        public AppDbContext() : base("DefaultConnection")
        {            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public DbSet<Crop> Crops { get; set; }

        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<DiseaseReport> DiseasesReport { get; set; }

        public DbSet<User> Users { get; set; }
    }
}