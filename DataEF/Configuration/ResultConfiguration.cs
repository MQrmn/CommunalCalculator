using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataEF
{
    internal class ResultConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne<ServiceType>(p => p.ServiceTypeID)
                .WithMany(p => p.Results)
                .HasForeignKey(p => p.ServiceType);
        }
    }
}
