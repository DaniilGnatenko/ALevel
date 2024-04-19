using Order.Host.Data;
using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;
using Order.Host.Repositories.Interfaces;

namespace Order.Host.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(ApplicationDbContext dbContext, ILogger<OrderRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<int> CreateOrder(string userId, List<OrderItemDto> items)
    {
        List<OrderItemEntity> newItems = new List<OrderItemEntity>();

        if (items == null)
        {
            return 0;
        }

        foreach (var item in items)
        {
            newItems.Add(new OrderItemEntity()
            {
                CatalogItemId = item.ItemId,
                Name = item.Name,
                PricePerItem = item.PricePerOne,
                Amount = item.Amount
            });
        }

        var totalPrice = 0;

        for (int i = 0; i < newItems.Count; i++)
        {
            totalPrice += newItems[i].PricePerItem * newItems[i].Amount;
        }

        var result = await _dbContext.OrderEntities.AddAsync(new OrderEntity()
        {
            TotalPrice = totalPrice,
            CreatedDate = DateTime.UtcNow,
            Items = newItems,
            UserID = userId
        });

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<List<OrderEntity>> GetOrdersAsync(string userId)
    {
        return await _dbContext.OrderEntities.Where(w => w.UserID == userId)
            .Include(i => i.Items)
            .ToListAsync();
    }
}
