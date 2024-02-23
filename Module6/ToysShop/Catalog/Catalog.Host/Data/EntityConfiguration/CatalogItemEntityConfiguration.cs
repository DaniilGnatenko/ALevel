using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Host.Data.EntityConfiguration;

public class CatalogItemEntityConfiguration : IEntityTypeConfiguration<CatalogItemEntity>
{
    public void Configure(EntityTypeBuilder<CatalogItemEntity> builder)
    {
        builder.ToTable("CatalogItem");

        builder.Property(p => p.Id)
            .UseHiLo("catalog_hilo")
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired(true)
            .HasMaxLength(75);

        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(200);

        builder.Property(p => p.Price)
            .IsRequired(true);

        builder.Property(p => p.PictureFileName)
            .IsRequired(false);

        builder.HasOne(h => h.CatalogBrand)
            .WithMany()
            .HasForeignKey(h => h.CatalogBrandId);

        builder.HasOne(h => h.CatalogType)
            .WithMany()
            .HasForeignKey(h => h.CatalogTypeId);
    }
}
