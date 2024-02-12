using HomeworkModule4Lesson6.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson6.Data.EntitiesConfiguration;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .HasMany(h => h.Pets)
            .WithOne(w => w.Category)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
            
        builder
            .HasMany(h => h.Breeds)
            .WithOne(w => w.Category)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
