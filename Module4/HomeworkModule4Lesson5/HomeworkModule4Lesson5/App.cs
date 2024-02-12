using ALevelSample.Models;
using ALevelSample.Services.Abstractions;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;
    private readonly IProductService _productService;

    public App(
        IUserService userService,
        IOrderService orderService,
        IProductService productService)
    {
        _userService = userService;
        _orderService = orderService;
        _productService = productService;
    }

    public async Task Start()
    {
        var firstName = "first name";
        var lastName = "last name";

        var userId = await _userService.AddUser(firstName, lastName);
        var userId1 = await _userService.AddUser("Some Name", "Some Last Name");
        var userId2 = await _userService.AddUser("Another Name", "Another Last Name");

        await _userService.GetUser(userId);

        await _userService.UpdateUser(userId, "New First Name", "New Last Name");

        await _userService.DeleteUser(userId1);

        var product1 = await _productService.AddProductAsync("product1", 4);
        var product2 = await _productService.AddProductAsync("product2", 7);
        var product3 = await _productService.AddProductAsync("product3", 9);
        var product4 = await _productService.AddProductAsync("product4", 15);

        await _productService.UpdateProductAsync(product3, 11);

        await _productService.GetProductAsync(product3);

        await _productService.DeleteProductAsync(product4);

        var order1 = await _orderService.AddOrderAsync(userId, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 3,
                ProductId = product1
            },

            new OrderItem()
            {
                Count = 6,
                ProductId = product2
            },
        });

        var order2 = await _orderService.AddOrderAsync(userId, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 1,
                ProductId = product1
            },

            new OrderItem()
            {
                Count = 9,
                ProductId = product2
            },
        });

        var userOrder = await _orderService.GetOrderByUserIdAsync(userId);

        await _orderService.UpdateOrderAsync(order1, new List<OrderItem>()
        {
            new OrderItem()
            {
                Count = 5,
                ProductId = product2
            },

            new OrderItem()
            {
                Count = 1,
                ProductId = product3
            },
        });

        await _orderService.DeleteOrderAsync(order2);

        await _orderService.GetOrderAsync(order1);

        await _productService.GetPaginatedProductsAsync(0, 5);
    }
}