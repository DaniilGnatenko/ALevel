using HomeworkModule4Lesson6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson6.Data.EntitiesConfiguration;

public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder
              .HasOne(h => h.Breed)
              .WithMany(w => w.Pets)
              .HasForeignKey(h => h.BreedId)
              .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(h => h.Location)
            .WithMany(w => w.Pets)
            .HasForeignKey(h => h.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(h => h.Category)
            .WithMany(w => w.Pets)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
