using HomeworkModule4Lesson6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson6.Data.EntitiesConfiguration;

public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder
            .HasMany(h => h.Pets)
            .WithOne(w => w.Location)
            .HasForeignKey(h => h.LocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
