using Microsoft.EntityFrameworkCore;
using DataEF.Configuration;

namespace DataEF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<ServiceVolume> ServiceVolumes { get; set; }

        public AppDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommunalRateConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceVolumeConfiguration());
        }
    }
}