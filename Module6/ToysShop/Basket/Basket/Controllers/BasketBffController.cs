using Basket.Models.Requests;
using Basket.Models.Responses;
using Basket.Services.Interfaces;
using Infrastructure.Filters;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
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

    [HttpGet]
    [RateLimitFilter(50)]
    [ProducesResponseType(typeof(GetResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItems()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
        var response = await _basketService.GetItems(basketId!);

        if (response == null)
        {
            _logger.LogInformation("Not found items");
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet]
    [RateLimitFilter(50)]
    [ProducesResponseType(typeof(GetWithUserResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetItemsWithUser()
	{
		var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

		var response = await _basketService.GetItems(basketId!);

		if (response == null)
		{
			_logger.LogInformation("Not found items");
			return NotFound();
		}

		return Ok(new GetWithUserResponse()
        {
            Items = response.Items,
            UserKey = basketId!
        });
	}

    [HttpGet]
    [RateLimitFilter(50)]
    [ProducesResponseType(typeof(GetUserResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUser()
    {
        var basketId = User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;

        if (basketId == null)
        {
			_logger.LogInformation("User not logged in");
			return NotFound();
        }

        return Ok(new GetUserResponse()
        {
            UserKey = basketId!
        });
    }
}
