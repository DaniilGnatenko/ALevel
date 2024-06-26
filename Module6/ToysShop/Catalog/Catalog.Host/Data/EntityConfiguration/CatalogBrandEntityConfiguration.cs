﻿using Catalog.Host.Data.Entities;
namespace Catalog.Host.Data.EntityConfiguration;

public class CatalogBrandEntityConfiguration : IEntityTypeConfiguration<CatalogBrandEntity>
{
    public void Configure(EntityTypeBuilder<CatalogBrandEntity> builder)
    {
        builder.ToTable("CatalogBrand");

        builder.HasKey(h => h.Id);

        builder.Property(p => p.Id)
            .UseHiLo("catalog_brand_hilo")
            .IsRequired();

        builder.Property(p => p.BrandName)
            .IsRequired(true)
            .HasMaxLength(50);
    }
}
