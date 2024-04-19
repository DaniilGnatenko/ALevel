using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using Order.Host.Data;
using Order.Host.Models.Dtos;
using Order.Host.Repositories.Interfaces;
using Order.Host.Services;
using Order.Host.Services.Interfaces;
using FluentAssertions;
using Order.Host.Data.Entities;

namespace Order.UnitTests.Services;

public class OrderServiceTest
{
	private readonly IOrderService _orderService;

	private readonly Mock<IOrderRepository> _orderRepository;
	private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
	private readonly Mock<ILogger<OrderService>> _logger;

	public OrderServiceTest()
	{
		_orderRepository = new Mock<IOrderRepository>();
		_dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
		_logger = new Mock<ILogger<OrderService>>();

		var dbContextTransaction = new Mock<IDbContextTransaction>();
		_dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

		_orderService = new OrderService(_dbContextWrapper.Object, _logger.Object, _orderRepository.Object);
	}

	[Fact]
	public async Task GetOrders_Success()
	{
		var userKey = Guid.NewGuid().ToString();
		var date = DateTime.UtcNow;

		var listOfOrderEntity = new List<OrderEntity>()
		{
			new OrderEntity()
			{
				Id = 1,
				CreatedDate = date,
				TotalPrice = 1000,
				UserID = userKey,
				Items = new List<OrderItemEntity>
				{
					new OrderItemEntity()
					{
						Id = 1,
						CatalogItemId = 1,
						Name = "test name",
						PricePerItem = 1000,
						Amount = 1,
						OrderId = 1
					}
				}
			}
		};

		var listOfOrdersSuccess = new List<OrderDto>()
		{
			new OrderDto()
			{
				Id = 1,
				CreatedDate = date,
				TotalPrice = 1000,
				UserId = userKey,
				Items = new List<OrderItemDto>
				{
					new OrderItemDto()
					{
						ItemId = 1,
						Name = "test name",
						PricePerOne = 1000,
						Amount = 1
					}
				}
			}
		};

		_orderRepository.Setup(s => s.GetOrdersAsync(
			It.Is<string>(i => i == userKey))).ReturnsAsync(listOfOrderEntity);

		var result = await _orderService.GetOrders(userKey);

		// assert
		result.Should().NotBeNull();
		result?[0].Should().NotBeNull();
	}

	[Fact]
	public async Task GetOrders_Failed()
	{
		var userKey = Guid.NewGuid().ToString();

		_orderRepository.Setup(s => s.GetOrdersAsync(
			It.Is<string>(i => i == userKey))).ReturnsAsync((Func<List<OrderEntity>>)null!);

		// act
		var result = await _orderService.GetOrders(userKey);

		// assert
		result.Should().BeNull();
	}

	[Fact]
	public async Task CreateOrder_Success()
	{
		var userKey = Guid.NewGuid().ToString();

		var orderId = 1;

		var listOfOrderItems = new List<OrderItemDto>()
		{
			new OrderItemDto()
				{
					ItemId = 1,
					Name = "test name",
					PricePerOne = 1000,
					Amount = 1
				}
		};

		_orderRepository.Setup(s => s.CreateOrder(
			It.Is<string>(i => i == userKey),
			It.Is<List<OrderItemDto>>(i => i == listOfOrderItems))).ReturnsAsync(orderId);

		var result = await _orderService.CreateOrder(userKey, listOfOrderItems);

		// assert
		result.Should().Be(orderId);
	}

	[Fact]
	public async Task CreateOrder_Failed()
	{
		var userKey = Guid.NewGuid().ToString();

		var orderId = 0;

		List<OrderItemDto> listOfOrderItems = null;

		_orderRepository.Setup(s => s.CreateOrder(
			It.Is<string>(i => i == userKey),
			It.Is<List<OrderItemDto>>(i => i == listOfOrderItems))).ReturnsAsync(orderId);

		var result = await _orderService.CreateOrder(userKey, listOfOrderItems);

		// assert
		result.Should().Be(orderId);
	}
}