using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task<bool> LogTestMessage();
        Task<bool> LogUserIdMessage();
        Task<Basket> AddToBasket(int id);
    }
}
