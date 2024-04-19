using MVC.Models.Requests;
using MVC.Models.Responses;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services;
public class BasketService : IBasketService
{
    private readonly IOptions<AppSettings> _settings;
    private readonly IHttpClientService _httpClient;
    private readonly ILogger<BasketService> _logger;

    public BasketService(IHttpClientService httpClient, ILogger<BasketService> logger, IOptions<AppSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Basket> GetBasket()
    {
        _logger.LogInformation($"Get request from basket controller");

        var result = await _httpClient.SendAsync<GetBasketResponse>($"{_settings.Value.BasketBffUrl}/getitems", HttpMethod.Get);

        if (result == null)
        {
			_logger.LogInformation($"Basket without items");
			return new Basket() { Items = new List<OrderItem>() { } };
		}

        _logger.LogInformation($"Get Basket success!");
        return new Basket() { Items = result.Items };
    }

    public async Task<int> AddToBasket(int id)
    {
        _logger.LogInformation($"Trying to find item with {id}");
        var item = await _httpClient.SendAsync<CatalogItem, IdRequest>(
            $"{_settings.Value.CatalogUrl}/item",
            HttpMethod.Post,
            new IdRequest() { Id = id });

        if (item == null || item.AvailableStock == 0)
        {
            _logger.LogInformation($"Item not found or out of stock");
            return 0;
        }

        _logger.LogInformation($"Found item with ID: {item.Id}, name - {item.Name}, price - {item.Price}");

        var result = await _httpClient.SendAsync<ItemActionResponse<OrderItem>, ItemRequest>(
            $"{_settings.Value.BasketItemUrl}/additem",
            HttpMethod.Post,
            new ItemRequest()
            {
                ItemId = item.Id,
                Name = item.Name,
                PricePerOne = item.Price
            });

        await _httpClient.SendAsync<ItemActionResponse<int>, UpdateProductStockRequest>(
            $"{_settings.Value.CatalogItemUrl}/updatestock",
            HttpMethod.Post,
            new UpdateProductStockRequest()
			{
                Id = item.Id,
                AvailableStock = item.AvailableStock - 1
			});

        _logger.LogInformation($"Changed available stock for item with ID: {item.Id}");

        _logger.LogInformation($"Item with  ID: {result.Result.ItemId} successfully added!");

        return result.Result.ItemId;
    }

    public async Task<int> RemoveItemFromBasket(int id)
    {
        _logger.LogInformation($"Trying to find item with {id}");
        var item = await _httpClient.SendAsync<CatalogItem, IdRequest>(
            $"{_settings.Value.CatalogUrl}/item",
            HttpMethod.Post,
            new IdRequest() { Id = id });

        if (item == null)
        {
			_logger.LogInformation($"Item not found");
			return 0;
        }

        _logger.LogInformation($"Found item with ID: {item.Id}, name - {item.Name}, price - {item.Price}");

        var result = await _httpClient.SendAsync<ItemActionResponse<int>, ItemIdRequest>(
            $"{_settings.Value.BasketItemUrl}/update",
            HttpMethod.Post,
            new ItemIdRequest() { ItemId = item.Id });

        await _httpClient.SendAsync<ItemActionResponse<int>, UpdateProductStockRequest>(
            $"{_settings.Value.CatalogItemUrl}/updatestock",
            HttpMethod.Post,
            new UpdateProductStockRequest()
			{
				Id = item.Id,
				AvailableStock = item.AvailableStock + 1
			});

        _logger.LogInformation($"Changed available stock for item with ID: {item.Id}");

        return result.Result;
    }

    public async Task<bool> DeleteItemFromBasket(int id, int amount)
    {
        _logger.LogInformation($"Trying to find item with {id}");
        var item = await _httpClient.SendAsync<CatalogItem, IdRequest>(
            $"{_settings.Value.CatalogUrl}/item",
            HttpMethod.Post,
            new IdRequest() { Id = id });

        if (item == null)
        {
			_logger.LogInformation($"Item not found");
			return false;
        }

        _logger.LogInformation($"Found item with ID: {item.Id}, name - {item.Name}, price - {item.Price}");

        var result = await _httpClient.SendAsync<ItemActionResponse<bool>, ItemIdRequest>(
            $"{_settings.Value.BasketItemUrl}/deleteitem",
            HttpMethod.Post,
            new ItemIdRequest() { ItemId = item.Id });

        await _httpClient.SendAsync<ItemActionResponse<int>, UpdateProductStockRequest>(
            $"{_settings.Value.CatalogItemUrl}/updatestock",
            HttpMethod.Post,
            new UpdateProductStockRequest()
			{
				Id = item.Id,
				AvailableStock = item.AvailableStock + amount
			});

        _logger.LogInformation($"Changed available stock for item with ID: {item.Id}");

        _logger.LogInformation($"Item in quantity: {amount} with ID: {id} successfully removed from basket!");

        return result.Result;
    }

    public async Task<bool> DeleteItemFromBasket(int id)
	{
		_logger.LogInformation($"Trying to find item with {id}");
		var item = await _httpClient.SendAsync<CatalogItem, IdRequest>(
            $"{_settings.Value.CatalogUrl}/item",
            HttpMethod.Post,
            new IdRequest() { Id = id });

		if (item == null)
		{
			_logger.LogInformation($"Item not found");
			return false;
		}

		_logger.LogInformation($"Found item with ID: {item.Id}, name - {item.Name}, price - {item.Price}");

		var result = await _httpClient.SendAsync<ItemActionResponse<bool>, ItemIdRequest>(
            $"{_settings.Value.BasketItemUrl}/deleteitem",
            HttpMethod.Post,
            new ItemIdRequest() { ItemId = item.Id });

		_logger.LogInformation($"Item with ID: {id} successfully deleted from basket!");

		return result.Result;
	}

    public async Task<bool> EmptyTheCart()
	{
        _logger.LogInformation($"Clearing the shopping cart by button");
        var basket = await GetBasket();

        if (basket.Items == null)
        {
			_logger.LogInformation($"basket is empty");
			return false;
        }

        foreach (var item in basket.Items)
        {
			_logger.LogInformation($"Deleting item with ID: {item.ItemId} from basket");
			await DeleteItemFromBasket(item.ItemId, item.Amount);
        }

        _logger.LogInformation($"Successfully cleared the shopping cart");
        return true;
	}

    public async Task<bool> EmptyTheCartWithoutAmount()
	{
		_logger.LogInformation($"Clearing the shopping cart to create an order");
		var basket = await GetBasket();

		if (basket.Items == null)
		{
			_logger.LogInformation($"basket is empty");
			return false;
		}

		foreach (var item in basket.Items)
		{
			_logger.LogInformation($"Deleting item with {item.ItemId} from basket");
			await DeleteItemFromBasket(item.ItemId);
		}

		_logger.LogInformation($"Successfully cleared the shopping cart");
		return true;
	}
}