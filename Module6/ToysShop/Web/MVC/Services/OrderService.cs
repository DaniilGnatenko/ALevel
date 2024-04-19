using MVC.Models.Requests;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;

public class OrderService : IOrderService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<OrderService> _logger;

    public OrderService(IHttpClientService httpClient, ILogger<OrderService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<CreateOrderResponse> CreateOrder()
    {
        var basket = await _httpClient.SendAsync<GetBasketWithUserResponse>($"{_settings.Value.BasketBffUrl}/getitemswithuser", HttpMethod.Get);

        var result = await _httpClient.SendAsync<CreateOrderResponse, CreateOrderRequest>(
            $"{_settings.Value.OrderUrl}/createorder",
            HttpMethod.Post,
            new CreateOrderRequest()
            {
                UserKey = basket.UserKey,
                Items = basket.Items
            });
        return result;
    }

    public async Task<GetOrdersResponse> GetOrders()
    {
        var user = await _httpClient.SendAsync<GetUserResponse>($"{_settings.Value.BasketBffUrl}/getuser", HttpMethod.Get);

        var result = await _httpClient.SendAsync<GetOrdersResponse, GetBasketRequest>(
            $"{_settings.Value.OrderBffUrl}/orders",
            HttpMethod.Post,
            new GetBasketRequest()
            {
                UserKey = user.UserKey
            });

        return result;
    }
}
