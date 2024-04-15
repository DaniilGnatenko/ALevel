using Order.Host.Data.Entities;
using Order.Host.Models.Dtos;

namespace Order.Host.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<int> CreateOrder(string userId, List<OrderItemDto> items);
        Task<List<OrderEntity>> GetOrdersAsync(string userId);
    }
}
