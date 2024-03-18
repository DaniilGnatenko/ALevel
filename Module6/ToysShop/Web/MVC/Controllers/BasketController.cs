using Microsoft.AspNetCore.Mvc;
using MVC.Services.Interfaces;

namespace MVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<AccountController> _logger;

        public BasketController(IBasketService basketService, ILogger<AccountController> logger)
        {
            _basketService = basketService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            _basketService.AddToBasket(5);

            var result1 = _basketService.LogTestMessage();
             _logger.LogInformation("LogTestMessage was used");


            var result2 = _basketService.LogUserIdMessage();
            _logger.LogInformation("LogUserIdMessage was used");

            

            if (result1.Result && result2.Result)
            {
                return Ok();
            }
            
            return BadRequest();
        }
    }
}
