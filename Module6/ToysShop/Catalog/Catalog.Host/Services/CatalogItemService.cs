using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using System.Xml.Linq;

namespace Catalog.Host.Services
{
    public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
    {

        private readonly ICatalogItemRepository _catalogItemRepository;

        public CatalogItemService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogItemRepository catalogItemRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        public Task<int?> Add(string name, string description, int price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Add(name, description, price, availableStock, catalogBrandId, catalogTypeId, pictureFileName));
        }

        public Task<bool> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Delete(id));
        }

        public Task<int?> Update(int id, string name, string description, int price, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            return ExecuteSafeAsync(() => _catalogItemRepository.Update(id, name, description, price, catalogBrandId, catalogTypeId, pictureFileName));
        }
    }
}
