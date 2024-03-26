using MVC.Models.Requests;
using MVC.Services.Interfaces;
using MVC.ViewModels;
using System.Net;

namespace MVC.Services;
public class BasketService :IBasketService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<CatalogService> _logger;

    public BasketService(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }


    public async Task<bool> LogTestMessage()
    {
       var result = await _httpClient.SendAsync($"{_settings.Value.BasketUrl}/testmessage", HttpMethod.Get);

        return result;
    }

    public async Task<bool> LogUserIdMessage()
    {
        var result = await _httpClient.SendAsync($"{_settings.Value.BasketUrl}/useridmessage", HttpMethod.Get);

        return result;
    }

    public async Task<Basket> AddToBasket(int id)
    {
        var result = await _httpClient.SendAsync<Basket, ItemRequest>($"http://localhost:5032/api/v1/basket/additemtobasket", HttpMethod.Post, 
            new ItemRequest()
            {
                Id = id
            });

        _logger.LogInformation($"{result.Items[0].Name} with {result.Items[0].Id}");

        return result;
    }

}
