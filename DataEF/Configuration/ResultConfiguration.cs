﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataEF.Configuration
{
    internal class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.ServiceType);
            builder.HasOne<BillingPeriod>(p => p.BillingPeriodId)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.BillingPeriod);
        }
    }
}
