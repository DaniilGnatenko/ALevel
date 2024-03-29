using Basket.Models.Requests;
using Basket.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BasketBffController : ControllerBase
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [RateLimitFilter(10)]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestAdd(TestAddRequest data)
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        await _basketService.TestAdd(basketId!, data.Data);
        return Ok();
    }

    [HttpPost]
    [RateLimitFilter(10)]
    [ProducesResponseType(typeof(TestGetResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> TestGet()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.TestGet(basketId!);
        return Ok(response);
    }
}
