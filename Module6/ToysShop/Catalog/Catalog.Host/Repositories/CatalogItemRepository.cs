using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogItemRepository> _logger;

        public CatalogItemRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<CatalogItemRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string name, string description, int price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            var item = await _dbContext.AddAsync(new CatalogItemEntity
            {
                CatalogBrandId = catalogBrandId,
                CatalogTypeId = catalogTypeId,
                Description = description,
                Name = name,
                PictureFileName = pictureFileName,
                Price = price
            });

            await _dbContext.SaveChangesAsync();

            return item.Entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var itemToDelete = await _dbContext.CatalogItemEntities.Where(w => w.Id == id).FirstOrDefaultAsync();

            if (itemToDelete != null)
            {
                _dbContext.CatalogItemEntities.Remove(itemToDelete);

                await _dbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<PaginatedItems<CatalogItemEntity>> GetByBrandAsync(int id, int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogItemEntities
                .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogItemEntities
                .Where(i => i.CatalogBrandId == id)
                .Include(i => i.CatalogBrand)
                .Include(i => i.CatalogType)
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogItemEntity>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<CatalogItemEntity> GetByIdAsync(int id)
        {
           return await _dbContext.CatalogItemEntities.Where(w => w.Id == id)
                .Include(i => i.CatalogBrand)
                .Include(i => i.CatalogType)
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedItems<CatalogItemEntity>> GetByPageAsync(int pageIndex, int pageSize)
        {

            var totalItems = await _dbContext.CatalogItemEntities
                .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogItemEntities
                .Include(i => i.CatalogBrand)
                .Include(i => i.CatalogType)
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogItemEntity>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<PaginatedItems<CatalogItemEntity>> GetByTypeAsync(int id, int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogItemEntities
                .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogItemEntities
                .Where(i => i.CatalogTypeId == id)
                .Include(i => i.CatalogBrand)
                .Include(i => i.CatalogType)
                .OrderBy(c => c.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogItemEntity>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<int?> Update(int id, string name, string description, int price, int catalogBrandId, int catalogTypeId, string pictureFileName)
        {
            var itemToUpdate = await _dbContext.CatalogItemEntities.Where(w => w.Id == id).FirstOrDefaultAsync();

            if (itemToUpdate != null)
            {
                itemToUpdate.Name = name;
                itemToUpdate.Description = description;
                itemToUpdate.Price = price;
                itemToUpdate.CatalogBrandId = catalogBrandId;
                itemToUpdate.CatalogBrand = await _dbContext.CatalogBrandEntities.Where(w => w.Id == catalogBrandId).FirstOrDefaultAsync();
                itemToUpdate.PictureFileName = pictureFileName;
                itemToUpdate.CatalogTypeId = catalogTypeId;
                itemToUpdate.CatalogType = await _dbContext.CatalogTypeEntities.Where(w => w.Id == catalogTypeId).FirstOrDefaultAsync();

                await _dbContext.SaveChangesAsync();

                return itemToUpdate.Id;
            }

            return null;
        }
    }
}
