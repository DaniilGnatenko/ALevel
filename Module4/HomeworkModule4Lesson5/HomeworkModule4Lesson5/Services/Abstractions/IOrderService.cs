using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IOrderService
{
    Task<int> AddOrderAsync(string user, List<OrderItem> items);
    Task<Order> GetOrderAsync(int id);
    Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(string id);
    Task<int> UpdateOrderAsync(int id, List<OrderItem> items);
    Task<bool> DeleteOrderAsync(int id);
}