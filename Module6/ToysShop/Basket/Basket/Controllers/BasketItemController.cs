using Basket.Models;
using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Controllers
{
    [ApiController]
    [Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
    [Scope("basket.basketitem")]
    [Route(ComponentDefaults.DefaultRoute)]
    public class BasketItemController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketItemController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemActionResponse<Item>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddItem(ItemRequest itemRequest)
        {
            var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var result = await _basketService.AddProduct(basketId!, itemRequest);
            return Ok(new ItemActionResponse<Item>() { Result = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemActionResponse<int>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(DeleteItemRequest itemRequest)
        {
            var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var result = await _basketService.RemoveProduct(basketId!, itemRequest);
            return Ok(new ItemActionResponse<int>() { Result = result });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ItemActionResponse<bool>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(DeleteItemRequest itemRequest)
        {
            var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            var result = await _basketService.DeleteProduct(basketId!, itemRequest);
            return Ok(new ItemActionResponse<bool>() { Result = result });
        }
    }
}
