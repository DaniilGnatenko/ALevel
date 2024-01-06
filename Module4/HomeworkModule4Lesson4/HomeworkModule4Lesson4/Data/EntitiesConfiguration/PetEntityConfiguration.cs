using HomeworkModule4Lesson4.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeworkModule4Lesson4.Data.EntitiesConfiguration
{
    internal class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder
                .ToTable("Pet")
                .HasKey(c => c.Id);

            builder
                .Property(c => c.Id)
                .HasColumnName("PetID");
        }
    }
}