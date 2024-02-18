using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] productNames = new[]
        {
            "Chocolate", "Cinnamon", "Frozen fish",  "Frozen meat", "Garlic", "Ginger", "Lemons", "Mandarins", "Mangos", "Onions"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }
        [HttpGet(Name = "GetProduct")]
        public IEnumerable<Product> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Quantity = Random.Shared.Next(0, 10),
                Price = Random.Shared.Next(20, 101),
                Name = productNames[Random.Shared.Next(productNames.Length)]
            })
                .ToArray();
        }
    }
}
