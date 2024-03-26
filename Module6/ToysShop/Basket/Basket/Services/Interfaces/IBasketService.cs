using Basket.Models.Dtos;

namespace Basket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDto> AddItemToBasket(int id);
    }
}
