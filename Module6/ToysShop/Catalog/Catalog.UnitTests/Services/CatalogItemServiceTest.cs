namespace Catalog.UnitTests.Services;

public class CatalogItemServiceTest
{
    private readonly ICatalogItemService _catalogItemService;

    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;

    private readonly CatalogItemEntity _testItem = new CatalogItemEntity()
    {
        Name = "Name",
        Description = "Description",
        Price = 1000,
        AvailableStock = 100,
        CatalogBrandId = 1,
        CatalogTypeId = 1,
        PictureFileName = "1.png"
    };

    public CatalogItemServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogItemService = new CatalogItemService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object);
    }

    [Fact]
    public async Task Add_Success()
    {
        // arrange
        var testResult = 1;

        _catalogItemRepository.Setup(s => s.Add(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Add(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Add_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogItemRepository.Setup(s => s.Add(
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Add(_testItem.Name, _testItem.Description, _testItem.Price, _testItem.AvailableStock, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Success()
    {
        // arrange
        int? testResult = 1;

        _catalogItemRepository.Setup(s => s.Update(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Update(_testItem.Id, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName, _testItem.AvailableStock);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Failed()
    {
        // arrange
        int? testResult = null;

        _catalogItemRepository.Setup(s => s.Update(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Update(_testItem.Id, _testItem.Name, _testItem.Description, _testItem.Price, _testItem.CatalogBrandId, _testItem.CatalogTypeId, _testItem.PictureFileName, _testItem.AvailableStock);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task UpdateStock_Success()
	{
		// arrange
		int? testResult = 1;

		_catalogItemRepository.Setup(s => s.Update(
			It.IsAny<int>(),
			It.IsAny<int>())).ReturnsAsync(testResult);

		// act
		var result = await _catalogItemService.Update(_testItem.Id, _testItem.AvailableStock);

		// assert
		result.Should().Be(testResult);
	}

    [Fact]
    public async Task UpdateStock_Failed()
	{
		// arrange
		int? testResult = null;

		_catalogItemRepository.Setup(s => s.Update(
			It.IsAny<int>(),
			It.IsAny<int>())).ReturnsAsync(testResult);

		// act
		var result = await _catalogItemService.Update(_testItem.Id, _testItem.AvailableStock);

		// assert
		result.Should().Be(testResult);
	}

    [Fact]
    public async Task Delete_Success()
    {
        // arrange
        bool testResult = true;

        _catalogItemRepository.Setup(s => s.Delete(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Delete(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Failed()
    {
        // arrange
        bool testResult = false;

        _catalogItemRepository.Setup(s => s.Delete(
            It.IsAny<int>())).ReturnsAsync(testResult);

        // act
        var result = await _catalogItemService.Delete(_testItem.Id);

        // assert
        result.Should().Be(testResult);
    }
}
