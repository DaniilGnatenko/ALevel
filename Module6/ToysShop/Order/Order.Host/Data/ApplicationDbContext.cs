using Order.Host.Data.Entities;
using Order.Host.Data.EntityConfiguration;

namespace Order.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        public DbSet<OrderEntity> OrderEntities { get; set; }
        public DbSet<OrderItemEntity> OrderItemEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderEntityConfiguration());
            builder.ApplyConfiguration(new OrderItemEntityConfiguration());
        }
    }
}
