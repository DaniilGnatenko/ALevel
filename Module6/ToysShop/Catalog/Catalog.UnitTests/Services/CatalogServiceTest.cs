using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;
using Moq;

namespace Catalog.UnitTests.Services;

public class CatalogServiceTest
{
    private readonly ICatalogService _catalogService;

    private readonly Mock<ICatalogItemRepository> _catalogItemRepository;
    private readonly Mock<ICatalogBrandRepository> _catalogBrandRepository;
    private readonly Mock<ICatalogTypeRepository> _catalogTypeRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<CatalogService>> _logger;

    public CatalogServiceTest()
    {
        _catalogItemRepository = new Mock<ICatalogItemRepository>();
        _catalogBrandRepository = new Mock<ICatalogBrandRepository>();
        _catalogTypeRepository = new Mock<ICatalogTypeRepository>();
        _mapper = new Mock<IMapper>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<CatalogService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _catalogService = new CatalogService(_dbContextWrapper.Object, _logger.Object, _catalogItemRepository.Object, _catalogBrandRepository.Object, _catalogTypeRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetCatalogItemsAsync_Success()
    {
        // arrange
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 10;

        var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogItemEntity>()
        {
            Data = new List<CatalogItemEntity>()
            {
                new CatalogItemEntity()
                {
                    Name = "TestName",
                },
            },
            TotalCount = testTotalCount,
        };

        var catalogItemSuccess = new CatalogItemEntity()
        {
            Name = "TestName"
        };

        var catalogItemDtoSuccess = new CatalogItemDto()
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize),
            It.IsAny<int?>(),
            It.IsAny<int?>())).ReturnsAsync(pagingPaginatedItemsSuccess);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
            It.Is<CatalogItemEntity>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

        // act
        var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex, null);

        // assert
        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogItemsAsync_Failed()
    {
        // arrange
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogItemRepository.Setup(s => s.GetByPageAsync(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize),
            It.IsAny<int?>(),
            It.IsAny<int?>())).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

        // act
        var result = await _catalogService.GetCatalogItemsAsync(testPageSize, testPageIndex, null);

        // assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_Success()
    {
        var testId = 1;

        var catalogItemSuccess = new CatalogItemEntity()
        {
            Name = "TestName"
        };

        var catalogItemDtoSuccess = new CatalogItemDto()
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).ReturnsAsync(catalogItemSuccess);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
            It.Is<CatalogItemEntity>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

        var result = await _catalogService.GetByIdAsync(testId);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetByIdAsync_Failed()
    {
        var testId = 1;

        var catalogItemSuccess = new CatalogItemEntity()
        {
            Name = "TestName"
        };

        var catalogItemDtoSuccess = new CatalogItemDto()
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(s => s.GetByIdAsync(
            It.IsAny<int>())).Returns((Func<CatalogItemDto>)null!);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
            It.Is<CatalogItemEntity>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

        var result = await _catalogService.GetByIdAsync(testId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByBrandAsync_Success()
    {
        var testId = 1;
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 1;

        var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogItemEntity>()
        {
            TotalCount = testTotalCount,
            Data = new List<CatalogItemEntity>()
            {
                new CatalogItemEntity()
                {
                    Name = "TestName"
                },
            }           
        };

        var catalogItemSuccess = new CatalogItemEntity()
        {
            Name = "TestName"
        };

        var catalogItemDtoSuccess = new CatalogItemDto()
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(s => s.GetByBrandAsync(
            It.Is<int>(i => i == testId),
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemsSuccess);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
            It.Is<CatalogItemEntity>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

        var result = await _catalogService.GetByBrandAsync(testId, testPageSize, testPageIndex);

        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetByBrandAsync_Failed()
    {
        var testId = 50;
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogItemRepository.Setup(s => s.GetByBrandAsync(
            It.Is<int>(i => i == testId),
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

        var result = await _catalogService.GetByBrandAsync(testId, testPageSize, testPageIndex);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByTypeAsync_Success()
    {
        var testId = 1;
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 2;

        var pagingPaginatedItemsSuccess = new PaginatedItems<CatalogItemEntity>()
        {
            TotalCount = testTotalCount,
            Data = new List<CatalogItemEntity>()
            {
                new CatalogItemEntity()
                {
                    Name = "TestName",
                },
            }            
        };

        var catalogItemSuccess = new CatalogItemEntity()
        {
            Name = "TestName"
        };

        var catalogItemDtoSuccess = new CatalogItemDto()
        {
            Name = "TestName"
        };

        _catalogItemRepository.Setup(s => s.GetByTypeAsync(
            It.Is<int>(i => i == testId),
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedItemsSuccess);

        _mapper.Setup(s => s.Map<CatalogItemDto>(
            It.Is<CatalogItemEntity>(i => i.Equals(catalogItemSuccess)))).Returns(catalogItemDtoSuccess);

        var result = await _catalogService.GetByTypeAsync(testId, testPageSize, testPageIndex);

        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetByTypeAsync_Failed()
    {
        var testId = 50;
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogItemRepository.Setup(s => s.GetByTypeAsync(
            It.Is<int>(i => i == testId),
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogItemDto>>)null!);

        var result = await _catalogService.GetByTypeAsync(testId, testPageSize, testPageIndex);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCatalogBrandsAsync_Success()
    {
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 10;

        var pagingPaginatedBrandsSuccess = new PaginatedItems<CatalogBrandEntity>()
        {
            TotalCount = testTotalCount,
            Data = new List<CatalogBrandEntity>()
            {
                new CatalogBrandEntity()
                {
                    BrandName = "TestName",
                },
            }            
        };

        var catalogBrandsSuccess = new CatalogBrandEntity()
        {
            BrandName = "TestName"
        };

        var catalogBrandsDtoSuccess = new CatalogBrandDto()
        {
            BrandName = "TestName"
        };

        _catalogBrandRepository.Setup(s => s.GetBrands(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedBrandsSuccess);

        _mapper.Setup(s => s.Map<CatalogBrandDto>(
            It.Is<CatalogBrandEntity>(i => i.Equals(catalogBrandsSuccess)))).Returns(catalogBrandsDtoSuccess);

        var result = await _catalogService.GetCatalogBrandsAsync(testPageSize, testPageIndex);

        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogBrandsAsync_Failed()
    {
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogBrandRepository.Setup(s => s.GetBrands(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogBrandDto>>)null!);

        var result = await _catalogService.GetCatalogBrandsAsync(testPageSize, testPageIndex);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCatalogTypesAsync_Success()
    {
        var testPageIndex = 0;
        var testPageSize = 4;
        var testTotalCount = 10;

        var pagingPaginatedTypesSuccess = new PaginatedItems<CatalogTypeEntity>()
        {
            TotalCount = testTotalCount,
            Data = new List<CatalogTypeEntity>()
            {
                new CatalogTypeEntity()
                {
                    TypeName = "TestName",
                },
            } 
        };

        var catalogTypesSuccess = new CatalogTypeEntity()
        {
            TypeName = "TestName"
        };

        var catalogTypesDtoSuccess = new CatalogTypeDto()
        {
            TypeName = "TestName"
        };

        _catalogTypeRepository.Setup(s => s.GetTypes(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).ReturnsAsync(pagingPaginatedTypesSuccess);

        _mapper.Setup(s => s.Map<CatalogTypeDto>(
            It.Is<CatalogTypeEntity>(i => i.Equals(catalogTypesSuccess)))).Returns(catalogTypesDtoSuccess);

        var result = await _catalogService.GetCatalogTypesAsync(testPageSize, testPageIndex);

        result.Should().NotBeNull();
        result?.Data.Should().NotBeNull();
        result?.Count.Should().Be(testTotalCount);
        result?.PageIndex.Should().Be(testPageIndex);
        result?.PageSize.Should().Be(testPageSize);
    }

    [Fact]
    public async Task GetCatalogTypesAsync_Failed()
    {
        var testPageIndex = 1000;
        var testPageSize = 10000;

        _catalogTypeRepository.Setup(s => s.GetTypes(
            It.Is<int>(i => i == testPageIndex),
            It.Is<int>(i => i == testPageSize))).Returns((Func<PaginatedItemsResponse<CatalogTypeDto>>)null!);

        var result = await _catalogService.GetCatalogTypesAsync(testPageSize, testPageIndex);

        result.Should().BeNull();
    }
}
