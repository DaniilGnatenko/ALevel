using HomeworkModule4Lesson6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson6.Data.EntitiesConfiguration;

internal class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure(EntityTypeBuilder<BreedEntity> builder)
    {
        builder
            .HasMany(h => h.Pets)
            .WithOne(w => w.Breed)
            .HasForeignKey(h => h.BreedId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
