using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<ItemResponse<CatalogItemDto>> GetByIdAsync(int id);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByBrandAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByTypeAsync(int id, int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetCatalogBrandsAsync(int pageSize, int pageIndex);
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetCatalogTypesAsync(int pageSize, int pageIndex);
}
