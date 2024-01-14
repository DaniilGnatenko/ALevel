using HomeworkModule4Lesson6.Data.Entities;
using HomeworkModule4Lesson6.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace HomeworkModule4Lesson6.Data;

public class PetDBContext : DbContext
{
    public DbSet<PetEntity> Pets { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;
    public DbSet<BreedEntity> Breeds { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;

    public PetDBContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
        modelBuilder.UseHiLo();
    }
}
