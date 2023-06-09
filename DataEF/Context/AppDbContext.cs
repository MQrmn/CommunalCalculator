﻿using Microsoft.EntityFrameworkCore;
using DataEF.Configuration;

namespace DataEF
{
    public class AppDbContext : DbContext
    {
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<MeterValue> MeterValues { get; set; }
        public DbSet<BillingPeriod> BillingPeriods { get; set; }

        public AppDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=base.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CommunalRateConfiguration());
            modelBuilder.ApplyConfiguration(new ResultConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MeterValueConfiguration());
            modelBuilder.ApplyConfiguration(new BillingPeriodConfiguration());
        }
    }
}