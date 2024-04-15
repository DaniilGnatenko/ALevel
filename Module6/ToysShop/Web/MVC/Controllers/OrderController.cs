using Microsoft.AspNetCore.Mvc;
using MVC.Services.Interfaces;
using MVC.ViewModels;
using MVC.ViewModels.OrderViewModel;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger, IBasketService basketService)
        {
            _orderService = orderService;
            _logger = logger;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Trying to get orders");
            var result = await _orderService.GetOrders();

            if (result == null)
            {
				_logger.LogInformation("Orders not found");
				return View();
			}

            _logger.LogInformation("Orders was found");
            var vm = new IndexViewModel()
            {
                Orders = result.Orders,
            };

            return View(vm);
        }

        public async Task<IActionResult> Detail(int id)
		{
            _logger.LogInformation($"Trying to get details for order with id: {id}");
            var result = await _orderService.GetOrders();
            var vm = result.Orders.FirstOrDefault(x => x.Id == id);
            return View(vm);
		}

        public async Task<IActionResult> CreateOrder()
		{
            var result = await _orderService.CreateOrder();
            await _basketService.EmptyTheCartWithoutAmount();
            _logger.LogInformation($"Created order with ID: {result.OrderId}");

            return RedirectToAction("Index", "Order");
		}
	}
}
