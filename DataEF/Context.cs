using System.Collections.Generic;
using System.Reflection.Emit;

namespace DataEF
{
    public class AppDbContext
    {
        public DbSet<VacStatsReqEntity> VacStatsReq { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VacStatsReqConfig());
            modelBuilder.ApplyConfiguration(new VacStatsRespConfig());
        }
    }
}