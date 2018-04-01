
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Admin_Backend.Models.DbModels;

namespace Admin_Backend.Models {

    public class ApveraDbContext : DbContext {

        private string conectionString=string.Empty;
        public ApveraDbContext(string connectionString)
        {
this.conectionString=connectionString;
        }

        public ApveraDbContext(DbContextOptions<ApveraDbContext> options)
            :base(options) {

        }

        public DbSet<SensorType> SensorType { get; set; }
        public DbSet<Sensor> Sensor { get; set; }

        public DbSet<Website> Website { get; set; }

        public DbSet<IpPage> IpPage { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<RuleEditor> RuleEditor { get; set; }

        public DbSet<SensorInstallation> SensorInstallation { get; set; }

        public DbSet<Port> Ports { get; set; }

        public DbSet<TrailsCategory> TrailsCategories { get; set; }

        public DbSet<TrailsSignature> TrailsSignature { get; set; }

protected override   void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    if(!optionsBuilder.IsConfigured && this.conectionString!=string.Empty){
        optionsBuilder.UseNpgsql(this.conectionString);
    }
}
        protected override void  OnModelCreating(ModelBuilder modelBuilder){

           modelBuilder.Entity<RuleEditor>().ToTable("SuricataRules");

           modelBuilder.Entity<TrailsSignature>().ToTable("TrailsSignatures");

           modelBuilder.Entity<SensorType>().HasKey(x=>x.Id);

           modelBuilder.Entity<TrailsSignature>().HasKey(x=>x.Sid);


           modelBuilder.Entity<Sensor>().HasKey(x=>x.Id);

           modelBuilder.Entity<Website>().HasKey(x=>x.Id);

           modelBuilder.Entity<IpPage>().HasKey(x=>x.Id);

           modelBuilder.Entity<Users>().HasKey(x=>x.Id);

           modelBuilder.Entity<RuleEditor>().HasKey(x=>x.Id);

           modelBuilder.Entity<SensorInstallation>().HasKey(x=>x.Id);

           modelBuilder.Entity<Port>().HasKey(x=>x.Id);

           modelBuilder.Entity<TrailsCategory>().HasKey(x=>x.Id);
        }
        
    }
}