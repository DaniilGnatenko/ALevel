using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfiguration;

public class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemEntity>
{
    public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .UseHiLo("orderitem_hilo")
            .IsRequired();

        builder.Property(p => p.CatalogItemId)
            .IsRequired();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(75);

        builder.Property(p => p.PricePerItem)
            .IsRequired();

        builder.Property(p => p.Amount)
            .IsRequired();
    }
}