using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF.Configuration
{
    internal class BillingPeriodConfiguration : IEntityTypeConfiguration<BillingPeriod>
    {
        public void Configure(EntityTypeBuilder<BillingPeriod> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Date).HasColumnType("date");
        }
    }
}
