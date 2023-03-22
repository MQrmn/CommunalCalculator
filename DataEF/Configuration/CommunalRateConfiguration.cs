using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF
{
    internal class CommunalRateConfiguration : IEntityTypeConfiguration<CommunalRate>
    {
        public void Configure(EntityTypeBuilder<CommunalRate> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Cost).IsRequired();
            builder.Property(p => p.Normative);
        }
    }
}
