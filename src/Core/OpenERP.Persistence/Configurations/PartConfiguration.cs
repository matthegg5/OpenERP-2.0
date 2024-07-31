
using OpenERP.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OpenERP.Infrastructure.Persistence.Configurations
{
    public class PartConfiguration
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.Property(p => p.PartNum)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}