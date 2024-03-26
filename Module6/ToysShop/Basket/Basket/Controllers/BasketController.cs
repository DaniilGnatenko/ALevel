using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Basket.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("basket.basketitem")]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketController : ControllerBase
{
    private readonly ILogger<BasketController> _logger;
    private readonly IBasketService _basketService;

    public BasketController(
        ILogger<BasketController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddItemToBasket(CatalogItemRequest request)
    {
        var result = await _basketService.AddItemToBasket(request.Id);
        _logger.LogInformation($"{result.Items[0].Id}");
        return Ok(new AddItemResponse() { BasketDto = result });
    }
}

