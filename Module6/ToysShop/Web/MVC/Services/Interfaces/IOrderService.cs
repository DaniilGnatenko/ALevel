using MVC.Models.Responses;

namespace MVC.Services.Interfaces
{
    public interface IOrderService
    {
        Task<CreateOrderResponse> CreateOrder();
        Task<GetOrdersResponse> GetOrders();
    }
}
