using Order.Host.Models.Dtos;

namespace Order.Host.Services.Interfaces;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrders(string userId);
    Task<int> CreateOrder(string userId, List<OrderItemDto> items);
}
