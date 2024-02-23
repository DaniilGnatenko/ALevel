using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected ApplicationDbContext()
    {
    }
    public DbSet<CatalogBrandEntity> CatalogBrandEntities { get; set; }
    public DbSet<CatalogItemEntity> CatalogItemEntities { get; set; }
    public DbSet<CatalogTypeEntity> CatalogTypeEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CatalogBrandEntityConfiguration());
        builder.ApplyConfiguration(new CatalogItemEntityConfiguration());
        builder.ApplyConfiguration(new CatalogTypeEntityConfiguration());
    }
}
