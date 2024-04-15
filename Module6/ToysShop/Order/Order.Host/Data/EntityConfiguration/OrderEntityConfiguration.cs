using Order.Host.Data.Entities;

namespace Order.Host.Data.EntityConfiguration;

public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Order");

        builder.Property(p => p.Id)
            .UseHiLo("order_hilo")
            .IsRequired();

        builder.Property(p => p.CreatedDate)
            .IsRequired();

        builder.Property(p => p.TotalPrice)
            .IsRequired();
    }
}