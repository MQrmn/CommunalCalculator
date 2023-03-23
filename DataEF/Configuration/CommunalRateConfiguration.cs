using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF
{
    internal class CommunalRateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Cost).IsRequired();
            builder.Property(p => p.Normative);

            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Rates)
                .HasForeignKey(p => p.ServiceType);
        }
    }
}
