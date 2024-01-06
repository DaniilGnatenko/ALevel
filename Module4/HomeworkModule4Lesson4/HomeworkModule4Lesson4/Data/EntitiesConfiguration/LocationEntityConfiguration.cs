using HomeworkModule4Lesson4.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson4.Data.EntitiesConfiguration;

public sealed class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder
           .ToTable("Location")
           .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("LocationID");
    }
}