using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataEF.Configuration
{
    internal class ServiceVolumeConfiguration : IEntityTypeConfiguration<ServiceVolume>
    {
        public void Configure(EntityTypeBuilder<ServiceVolume> builder)
        {
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Volume).IsRequired();
            builder.HasOne<ServiceType>(p => p.ServiceTypeId)
                .WithMany(p => p.Volumes)
                .HasForeignKey(p => p.ServiceType);
        }
        
    }
}
