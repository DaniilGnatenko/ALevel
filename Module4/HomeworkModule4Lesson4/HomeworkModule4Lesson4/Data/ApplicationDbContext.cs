using HomeworkModule4Lesson4.Data.Entities;
using HomeworkModule4Lesson4.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace HomeworkModule4Lesson4.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<PetEntity> Pets { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<BreedEntity> Breeds { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {

    }

    protected ApplicationDbContext()
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BreedEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
    }
}