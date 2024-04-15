using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Host.Configurations;
using Order.Host.Models.Dtos;
using Order.Host.Models.Requests;
using Order.Host.Models.Responses;
using Order.Host.Services;
using Order.Host.Services.Interfaces;
using StackExchange.Redis;

namespace Order.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class OrderBffController : ControllerBase
{
    private readonly ILogger<OrderBffController> _logger;
    private readonly IOrderService _orderService;

    public OrderBffController(
        ILogger<OrderBffController> logger,
        IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetOrdersResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Orders(GetOrdersRequest request)
    {
        var result = await _orderService.GetOrders(request.UserKey);
        return Ok(new GetOrdersResponse() { Orders = result });
    }
}
