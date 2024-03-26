using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfiguration;

public class CatalogTypeEntityConfiguration : IEntityTypeConfiguration<CatalogTypeEntity>
{
    public void Configure(EntityTypeBuilder<CatalogTypeEntity> builder)
    {
        builder.ToTable("CatalogType");

        builder.HasKey(h => h.Id);

        builder.Property(p => p.Id)
            .UseHiLo("catalog_type_hilo")
            .IsRequired();

        builder.Property(p => p.TypeName)
            .IsRequired(true)
            .HasMaxLength(50);
    }
}
