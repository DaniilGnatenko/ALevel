using Basket.Models;
using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;

namespace Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly ILogger<BasketService> _logger;
        private readonly ICacheService _cacheService;
        public BasketService(ILogger<BasketService> logger, ICacheService cacheService)
        {
            _logger = logger;
            _cacheService = cacheService;
        }

        public async Task<GetResponse> GetItems(string userId)
        {
            var result = await _cacheService.GetAsync<List<Item>>(userId);
            if (result == null)
            {
				return new GetResponse() { Items = new List<Item>() };
            }

            return new GetResponse() { Items = result };
        }

        public async Task<Item> AddProduct(string userId, ItemRequest item)
        {
            var products = await _cacheService.GetAsync<List<Item>>(userId);

            if (products == null)
            {
                products =
                [
                    new Item()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        Amount = 1,
                        PricePerOne = item.PricePerOne
                    },
                ];
                _logger.LogInformation(userId, products);
                await _cacheService.AddOrUpdateAsync(userId, products);
                return products[0];
            }
            else
            {
                var existed = products.FirstOrDefault(x => x.ItemId == item.ItemId);

                if (existed != null)
                {
                    products[products.IndexOf(existed)].Amount++;
                    await _cacheService.AddOrUpdateAsync(userId, products);
                    _logger.LogInformation(userId, products);
                    return products[products.IndexOf(existed)];
                }
                else
                {
                    products.Add(new Item()
                    {
                        ItemId = item.ItemId,
                        Name = item.Name,
                        Amount = 1,
                        PricePerOne = item.PricePerOne
                    });
                    await _cacheService.AddOrUpdateAsync(userId, products);
                    _logger.LogInformation(userId, products);
                    return products.FirstOrDefault(x => x.ItemId == item.ItemId);
                }
            }
        }

        public async Task<int> RemoveProduct(string userId, DeleteItemRequest item)
        {
            var products = await _cacheService.GetAsync<List<Item>>(userId);

            var existed = products.FirstOrDefault(x => x.ItemId == item.ItemId);

            if (existed == null)
            {
                return 0;
            }

            if (existed != null && existed.Amount > 1)
            {
                products[products.IndexOf(existed)].Amount -= 1;
            }
            else
            {
                products.Remove(existed!);
                await _cacheService.AddOrUpdateAsync(userId, products);
                return 0;
            }

            await _cacheService.AddOrUpdateAsync(userId, products);
            return products[products.IndexOf(existed)].ItemId;
        }

        public async Task<bool> DeleteProduct(string userId, DeleteItemRequest item)
        {
            var products = await _cacheService.GetAsync<List<Item>>(userId);

            var existed = products.FirstOrDefault(x => x.ItemId == item.ItemId);

            if (existed == null)
            {
                _logger.LogInformation("Not found");
                return false;
            }

            products.Remove(existed);
            await _cacheService.AddOrUpdateAsync(userId, products);

            return true;
        }
    }
}
