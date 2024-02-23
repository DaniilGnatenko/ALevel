using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Responses;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using System.Xml.Linq;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
        }

        public Task<int?> Add(string name)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.AddAsync(name));
        }

        public Task<bool> Delete(int id)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.DeleteAsync(id));
        }

        public Task<int?> Update(int id, string name)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.UpdateAsync(id, name));
        }
    }
}
