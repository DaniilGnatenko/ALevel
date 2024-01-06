using HomeworkModule4Lesson4.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson4.Data.EntitiesConfiguration;

public sealed class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder
            .ToTable("Category")
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Id)
            .HasColumnName("CategoryID");
    }
}