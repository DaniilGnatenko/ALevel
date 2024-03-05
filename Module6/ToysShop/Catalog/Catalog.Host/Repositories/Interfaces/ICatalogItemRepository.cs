using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogItemRepository
    {
        Task<PaginatedItems<CatalogItemEntity>> GetByPageAsync(int pageIndex, int pageSize);
        Task<PaginatedItems<CatalogItemEntity>> GetByBrandAsync(int id, int pageIndex, int pageSize);
        Task<PaginatedItems<CatalogItemEntity>> GetByTypeAsync(int id, int pageIndex, int pageSize);
        Task<CatalogItemEntity> GetByIdAsync(int id);
        Task<int?> Add(string name, string description, int price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task<int?> Update(int id, string name, string description, int price, int catalogBrandId, int catalogTypeId, string pictureFileName);
        Task<bool> Delete(int id);
    }
}
