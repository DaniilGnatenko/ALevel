using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddOrderAsync(string user, List<OrderItem> items)
    {
        var result = await _dbContext.Orders.AddAsync(new OrderEntity()
        {
            UserId = user
        });

        await _dbContext.OrderItems.AddRangeAsync(items.Select(s => new OrderItemEntity()
        {
            Count = s.Count,
            OrderId = result.Entity.Id,
            ProductId = s.ProductId
        }));

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<OrderEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).Where(f => f.UserId == id).ToListAsync();
    }

    public async Task<int> UpdateOrderAsync(int id, List<OrderItem> items)
    {
        var result = await _dbContext.Orders.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return 0;
        }

        var updatedOrder = new List<OrderItemEntity>();
        foreach (var item in items)
        {
            updatedOrder.Add(new OrderItemEntity()
            {
                Count = item.Count,
                OrderId = result.Id,
                ProductId = item.ProductId
            });
        }

        result.OrderItems = updatedOrder;

        await _dbContext.SaveChangesAsync();

        return result.Id;
    }

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var result = await _dbContext.Orders.FirstOrDefaultAsync(f => f.Id == id);

        if (result == null)
        {
            return false;
        }

        _dbContext.Orders.Remove(_dbContext.Orders.Single(a => a.Id == id));

        await _dbContext.SaveChangesAsync();

        return true;
    }
}