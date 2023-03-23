using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF.Configuration
{
    internal class MeterValueConfiguration : IEntityTypeConfiguration<MeterValue>
    {
        public void Configure(EntityTypeBuilder<MeterValue> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Volume).IsRequired();
            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Values)
                .HasForeignKey(p => p.ServiceType);
            builder.HasOne<BillingPeriod>(p => p.BillingPeriodId)
                .WithMany(p => p.MeterValues)
                .HasForeignKey(p => p.BillingPeriod);
        }
        
    }
}
