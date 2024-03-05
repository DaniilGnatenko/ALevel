using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<PaginatedItems<CatalogTypeEntity>> GetTypes(int pageIndex, int pageSize);
        Task<int?> Add(string name);
        Task<int?> Update(int id, string newName);
        Task<bool> Delete(int id);
    }
}
