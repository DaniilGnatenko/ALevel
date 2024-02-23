using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        
        Task<int?> Add(string name);
        Task<int?> Update(int id, string name);
        Task<bool> Delete(int id);
    }
}
