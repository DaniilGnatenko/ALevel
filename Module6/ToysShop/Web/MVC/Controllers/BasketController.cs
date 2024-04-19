using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Controllers
{
	public class BasketController : Controller
	{
		private readonly IBasketService _basketService;
		private readonly ILogger<BasketController> _logger;

		public BasketController(IBasketService basketService, ILogger<BasketController> logger)
		{
			_basketService = basketService;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			_logger.LogInformation($"Trying to get Basket");

			var result = await _basketService.GetBasket();

			foreach (var item in result.Items)
			{
				_logger.LogInformation($"In user basket - item {item.Name} with id : {item.ItemId}");
			}

			return View(result);
		}

		public async Task<IActionResult> AddToBasket(int id)
		{
			_logger.LogInformation($"Trying to add item with id: {id} to basket");
			var result = await _basketService.AddToBasket(id);
			if (result == 0)
			{
				_logger.LogInformation($"item was not added, out of stock");
			}
			else
			{
				_logger.LogInformation($"Successfully added item with id: {result} to basket");
			}

			return RedirectToAction("Index", "Basket");
		}

		public async Task<IActionResult> DeleteFromBasket(int id)
		{
			_logger.LogInformation($"Trying to get Basket");
			var basket = await _basketService.GetBasket();

			_logger.LogInformation($"Trying to find item with id: {id} in basket to delete it");
			var amount = basket.Items.FirstOrDefault(x => x.ItemId == id);

			_logger.LogInformation($"Call the delete method");
			await _basketService.DeleteItemFromBasket(id, amount.Amount);

			return RedirectToAction("Index", "Basket");
		}

		public async Task<IActionResult> RemoveFromBasket(int id)
		{
			_logger.LogInformation($"Trying to remove item with id: {id} in basket");
			await _basketService.RemoveItemFromBasket(id);

			return RedirectToAction("Index", "Basket");
		}

		public async Task<IActionResult> EmptyTheCart()
		{
			_logger.LogInformation($"Trying to empty the cart");
			await _basketService.EmptyTheCart();

			return RedirectToAction("Index", "Catalog");
		}
	}
}
