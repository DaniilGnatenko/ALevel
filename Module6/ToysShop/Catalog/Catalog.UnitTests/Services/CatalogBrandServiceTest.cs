using System.Runtime.CompilerServices;

namespace Catalog.UnitTests.Services;

public class CatalogBrandServiceTest
{
    private readonly ICatalogBrandService _catalogBrandService;

    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogBrandService>> _logger;

    private readonly CatalogBrandEntity _testBrand = new CatalogBrandEntity()
    {
        BrandName = "Test"
    };

    public CatalogBrandServiceTest()
    {
        _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger =  new Mock<ILogger<CatalogBrandService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogBrandService = new CatalogBrandService(_dbContextWrapper.Object, _logger.Object, _catalogBrandRepository.Object);
    }

    [Fact]
    public async Task Add_Success()
    {
        var testResult = 1;

        _catalogBrandRepository.Setup(s => s.AddAsync(
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Add(_testBrand.BrandName);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Add_Failed()
    {
        int? testResult = null;

        _catalogBrandRepository.Setup(s => s.AddAsync(
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Add(_testBrand.BrandName);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Update_Success()
    {
        var testResult = 1;

        _catalogBrandRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Update(_testBrand.Id, _testBrand.BrandName);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Update_Failed()
    {
        int? testResult = null;

        _catalogBrandRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Update(_testBrand.Id, _testBrand.BrandName);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Delete_Success()
    {
        var testResult = true;

        _catalogBrandRepository.Setup(s => s.DeleteAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Delete(_testBrand.Id);

        result.Should().Be(testResult);
    }
    
    [Fact]
    public async Task Delete_Failed()
    {
        var testResult = false;

        _catalogBrandRepository.Setup(s => s.DeleteAsync(
            It.IsAny<int>())).ReturnsAsync(testResult);

        var result = await _catalogBrandService.Delete(_testBrand.Id);

        result.Should().Be(testResult);
    }
}