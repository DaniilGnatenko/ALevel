using HomeworkModule4Lesson4.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson4.Data.EntitiesConfiguration;

public sealed class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure (EntityTypeBuilder<BreedEntity> builder)
    {
        builder
            .ToTable("Breed")
            .HasKey(p  => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("BreedId");
    }
}