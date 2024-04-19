using AutoMapper;
using Order.Host.Data;
using Order.Host.Models.Dtos;
using Order.Host.Repositories;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services.Interfaces;

namespace Order.Host.Services;

public class OrderService : BaseDataService<ApplicationDbContext>, IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IOrderRepository orderRepository)
        : base(dbContextWrapper, logger)
    {
        _orderRepository = orderRepository;
    }

    public Task<int> CreateOrder(string userId, List<OrderItemDto> items)
    {
        return ExecuteSafeAsync(() => _orderRepository.CreateOrder(userId, items));
    }

    public async Task<List<OrderDto>> GetOrders(string userId)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var orders = await _orderRepository.GetOrdersAsync(userId);

            var result = new List<OrderDto>();
            foreach (var item in orders)
            {
                var orderItems = new List<OrderItemDto>();
                foreach (var itemDto in item.Items)
                {
                    orderItems.Add(new OrderItemDto()
                    {
                        ItemId = itemDto.CatalogItemId,
                        Name = itemDto.Name,
                        Amount = itemDto.Amount,
                        PricePerOne = itemDto.PricePerItem
                    });
                }

                result.Add(new OrderDto
                {
                    Id = item.Id,
                    TotalPrice = item.TotalPrice,
                    CreatedDate = item.CreatedDate,
                    Items = orderItems,
                    UserId = item.UserID
                });
            }

            return result;
        });
    }
}
