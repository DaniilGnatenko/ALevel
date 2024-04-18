using Basket.Models;
using Basket.Models.Requests;
using Basket.Services;
using Basket.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Basket.UnitTests.Services
{
    public class BasketServiceTest
	{
		private readonly IBasketService _basketService;
		private readonly Mock<ICacheService> _cacheService;
		private readonly Mock<ILogger<BasketService>> _logger;

		public BasketServiceTest()
        {
			_cacheService = new Mock<ICacheService>();
			_logger = new Mock<ILogger<BasketService>>();
			_basketService = new BasketService(_logger.Object, _cacheService.Object);
		}

		[Fact]
		public async Task GetItems_Success()
		{
			var testData = new { userKey = "userID", listItem = new Item() { ItemId = 1, Amount = 1, Name = "Test Name", PricePerOne = 1000 } };

			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item> { testData.listItem });

			var result = await _basketService.GetItems(testData.userKey);

			result.Should().NotBeNull();
			result.Items.Should().NotBeNull();
			result.Items[0].Should().Be(testData.listItem);
		}

		[Fact]
		public async Task GetItems_Failed()
		{
			var testData = "userID";

			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync((Func<List<Item>>)null!);

			var result = await _basketService.GetItems(testData);

			result.Should().NotBeNull();
			result.Items.Should().HaveCount(0);
		}

		[Fact]
		public async Task AddProduct_Success()
		{
			var testData = new { userKey = "userID", listItem = new ItemRequest() { ItemId = 1, Name = "Test Name", PricePerOne = 1000 } };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>());

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Returns(Task.CompletedTask);

			var result = await _basketService.AddProduct(testData.userKey, testData.listItem);

			result.Should().NotBeNull();
			result.Amount.Should().Be(1);
		}

		[Fact]
		public async Task AddProduct_Failed()
		{
			var testData = new { userKey = "userID", testList = new ItemRequest() };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>());

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Throws(new Exception("Redis exception"));

			Func<Task<Item>> result = async () => await _basketService.AddProduct(testData.userKey, testData.testList);

			await Assert.ThrowsAsync<Exception>(result);
		}

		[Fact]
		public async Task RemoveProduct_Success()
		{
			var testData = new { userKey = "userID", testList = new DeleteItemRequest() { ItemId = 1 } };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>() { new Item() { ItemId = 1, Name = "Test Name", Amount = 2, PricePerOne = 1000 } });

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Returns(Task.CompletedTask);

			var result = await _basketService.RemoveProduct(testData.userKey, testData.testList);

			result.Should().NotBe(0);
			result.Should().Be(1);
		}

		[Fact]
		public async Task RemoveProduct_Failed()
		{
			var testData = new { userKey = "userID", testList = new DeleteItemRequest() };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>());

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Returns((Func<List<Item>>)null!);

			var result = await _basketService.RemoveProduct(testData.userKey, testData.testList);

			result.Should().Be(0);
		}

		[Fact]
		public async Task DeleteProduct_Success()
		{
			var testData = new { userKey = "userID", testList = new DeleteItemRequest() { ItemId = 1 } };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>() { new Item() { ItemId = 1, Name = "Test Name", Amount = 2, PricePerOne = 1000 } });

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Returns(Task.CompletedTask);

			var result = await _basketService.DeleteProduct(testData.userKey, testData.testList);

			result.Should().BeTrue();
		}

		[Fact]
		public async Task DeleteProduct_Failed()
		{
			var testData = new { userKey = "userID", testList = new DeleteItemRequest() };
			_cacheService.Setup(x => x.GetAsync<List<Item>>(It.IsAny<string>())).ReturnsAsync(new List<Item>());

			_cacheService.Setup(x => x.AddOrUpdateAsync(It.IsAny<string>(), It.IsAny<List<Item>>())).Returns((Func<List<Item>>)null!);

			var result = await _basketService.DeleteProduct(testData.userKey, testData.testList);

			result.Should().BeFalse();
		}
	}
}