using Catalog.Host.Data.Entities;
using Catalog.Host.Data;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<PaginatedItems<CatalogBrandEntity>> GetBrands(int pageIndex, int pageSize);
        Task<int?> AddAsync(string name);
        Task<int?> UpdateAsync(int id, string newName);
        Task<bool> DeleteAsync(int id);
    }
}
