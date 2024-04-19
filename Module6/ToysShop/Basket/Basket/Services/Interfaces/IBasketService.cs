using Basket.Models;
using Basket.Models.Requests;
using Basket.Models.Responses;

namespace Basket.Services.Interfaces;

public interface IBasketService
{
    Task<GetResponse> GetItems(string userId);
    Task<Item> AddProduct(string userId, ItemRequest item);
    Task<int> RemoveProduct(string userId, DeleteItemRequest item);
    Task<bool> DeleteProduct(string userId, DeleteItemRequest item);
}
