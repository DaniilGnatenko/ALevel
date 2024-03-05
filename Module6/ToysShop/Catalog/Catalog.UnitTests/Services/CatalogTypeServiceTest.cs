namespace Catalog.UnitTests.Services;

public class CatalogTypeServiceTest
{
    private readonly ICatalogTypeService _catalogTypeService;

    private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogTypeService>> _logger;

    private readonly CatalogTypeEntity _testType = new CatalogTypeEntity()
    {
        TypeName = "Test"
    };

    public CatalogTypeServiceTest()
    {
        _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogTypeService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogTypeService = new CatalogTypeService(_dbContextWrapper.Object, _logger.Object, _catalogTypeRepository.Object);
    }

    [Fact]
    public async Task Add_Success()
    {
        var testResult = 1;

        _catalogTypeRepository.Setup(s => s.Add(
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Add(_testType.TypeName);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Add_Failed()
    {
        int? testResult = null;

        _catalogTypeRepository.Setup(s => s.Add(
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Add(_testType.TypeName);

        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Success()
    {
        var testResult = 1;

        _catalogTypeRepository.Setup(s => s.Update(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Update(_testType.Id, _testType.TypeName);

        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Update_Failed()
    {
        int? testResult = null;

        _catalogTypeRepository.Setup(s => s.Update(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Update(_testType.Id, _testType.TypeName);

        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Success()
    {
        var testResult = true;

        _catalogTypeRepository.Setup(s => s.Delete(
            It.IsAny<int>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Delete(_testType.Id);

        result.Should().Be(testResult);
    }

    [Fact]
    public async Task Delete_Failed()
    {
        var testResult = false;

        _catalogTypeRepository.Setup(s => s.Delete(
            It.IsAny<int>())).ReturnsAsync(testResult);

        var result = await _catalogTypeService.Delete(_testType.Id);

        result.Should().Be(testResult);
    }
}
