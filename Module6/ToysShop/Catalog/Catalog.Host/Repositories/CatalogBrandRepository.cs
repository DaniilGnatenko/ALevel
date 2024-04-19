using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogBrandRepository : ICatalogBrandRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogBrandRepository> _logger;

        public CatalogBrandRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<CatalogBrandRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> AddAsync(string name)
        {
            var brand = await _dbContext.CatalogBrandEntities.AddAsync(new CatalogBrandEntity() { BrandName = name });

            await _dbContext.SaveChangesAsync();

            return brand.Entity.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var brandToDelete = await _dbContext.CatalogBrandEntities.Where(w => w.Id == id).FirstOrDefaultAsync();
            if (brandToDelete != null)
            {
                _dbContext.CatalogBrandEntities.Remove(brandToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PaginatedItems<CatalogBrandEntity>> GetBrands(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogBrandEntities
                 .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogBrandEntities
                .OrderBy(c => c.BrandName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogBrandEntity>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<int?> UpdateAsync(int id, string newName)
        {
            var brandToUpdate = await _dbContext.CatalogBrandEntities.Where(w => w.Id == id).FirstOrDefaultAsync();

            if (brandToUpdate != null)
            {
                brandToUpdate.BrandName = newName;
                await _dbContext.SaveChangesAsync();
                return brandToUpdate.Id;
            }

            return null;
        }
    }
}
