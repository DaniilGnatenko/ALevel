using Basket.Models.Dtos;
using Basket.Models.Requests;
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

        public async Task TestAdd(string userId, string data)
        {
            await _cacheService.AddOrUpdateAsync(userId, data);
        }

        public async Task<TestGetResponse> TestGet(string userId)
        {
            var result = await _cacheService.GetAsync<string>(userId);
            return new TestGetResponse() { Data = result };
        }
    }
}
