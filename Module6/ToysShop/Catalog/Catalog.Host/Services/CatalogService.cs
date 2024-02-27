using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ICatalogTypeRepository _catalogTypeRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        ICatalogBrandRepository catalogBrandRepository,
        ICatalogTypeRepository catalogTypeRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _catalogTypeRepository = catalogTypeRepository;
        _catalogBrandRepository = catalogBrandRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetByBrandAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByBrandAsync(id, pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<ItemResponse<CatalogItemDto>> GetByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByIdAsync(id);
            return new ItemResponse<CatalogItemDto>()
            {
                Item = _mapper.Map<CatalogItemDto>(result)
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetByTypeAsync(int id, int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByTypeAsync(id, pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>> GetCatalogBrandsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogBrandRepository.GetBrands(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogBrandDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex)
    {

        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<PaginatedItemsResponse<CatalogTypeDto>> GetCatalogTypesAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogTypeRepository.GetTypes(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogTypeDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogTypeDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }
}
