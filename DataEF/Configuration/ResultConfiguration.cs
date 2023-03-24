using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataEF.Configuration
{
    internal class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.VolumeOfServices).IsRequired().HasColumnType("decimal");
            builder.Property(p => p.Cost).IsRequired().HasColumnType("decimal");
            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.ServiceType);
            builder.HasOne<BillingPeriod>(p => p.BillingPeriodId)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.BillingPeriod);
        }
    }
}
