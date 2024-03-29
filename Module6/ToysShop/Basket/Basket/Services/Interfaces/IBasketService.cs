using Basket.Models.Requests;

namespace Basket.Services.Interfaces;

public interface IBasketService
{
    Task TestAdd(string userId, string data);
    Task<TestGetResponse> TestGet(string userId);
}
