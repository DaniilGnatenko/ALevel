using Basket.Models.Dtos;
using Basket.Models.Requests;
using Basket.Services.Interfaces;

namespace Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly ILogger<BasketService> _logger;
        private BasketDto _basket = new BasketDto()
        {
            TotalCount = 0,
            TotalPrice = 0,
            Items = new List<CatalogItemDto> { }
        };


        public BasketService(ILogger<BasketService> logger)
        {
            _logger = logger;
        }

        public async Task<BasketDto> AddItemToBasket(int id)
        {
            var newItem = new CatalogItemDto()
            {
                Id = id,
                Name = "testAddName",
                Description = "someDescription",
                Price = 1000,
                PictureUrl = "10.png",
                CatalogBrand = new CatalogBrand()
                {
                    Id = 2,
                    BrandName = "TestBrand"
                },
                CatalogType = new CatalogType()
                {
                    Id = 2,
                    TypeName = "TestType"
                },
                AvailableStock = 15
            };

           _basket.Items.Add(newItem);

            for (int i = 0; i < _basket.Items.Count; i++)
            {
               _basket.TotalPrice = _basket.Items[i].Price++;
            }
            _basket.TotalCount = _basket.Items.Count;

            _logger.LogInformation($"Added to basket Item with Id {id}");
            return _basket;
        }
    }
}
