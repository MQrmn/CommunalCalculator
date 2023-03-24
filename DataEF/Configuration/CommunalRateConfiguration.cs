using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF.Configuration
{
    internal class CommunalRateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Cost).IsRequired().HasColumnType("decimal");
            builder.Property(p => p.Normative).HasColumnType("decimal");
            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Rates)
                .HasForeignKey(p => p.ServiceType);
        }
    }
}
