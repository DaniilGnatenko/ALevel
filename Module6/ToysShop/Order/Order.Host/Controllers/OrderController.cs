using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Order.Host.Configurations;
using Order.Host.Models.Dtos;
using Order.Host.Models.Requests;
using Order.Host.Models.Responses;
using Order.Host.Services.Interfaces;

namespace Order.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("order.orderitem")]
[Route(ComponentDefaults.DefaultRoute)]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    public OrderController(
        ILogger<OrderController> logger,
        IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateOrderResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> CreateOrder(CreateOrderRequest request)
    {
        var result = await _orderService.CreateOrder(request.UserKey, request.Items);
        return Ok(new CreateOrderResponse() { OrderId = result });
    }
}
