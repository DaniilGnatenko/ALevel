using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
    public interface IBasketService
    {
        Task<int> AddToBasket(int id);
        Task<Basket> GetBasket();
        Task<int> RemoveItemFromBasket(int id);
        Task<bool> DeleteItemFromBasket(int id);
        Task<bool> DeleteItemFromBasket(int id, int amount);
        Task<bool> EmptyTheCart();
        Task<bool> EmptyTheCartWithoutAmount();
	}
}
