using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<CatalogItemDto> GetByIdAsync(int id);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetCatalogBrandsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetCatalogTypesAsync(int pageSize, int pageIndex);
}
