using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogTypeRepository> _logger;

        public CatalogTypeRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<CatalogTypeRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string name)
        {
            var type = await _dbContext.CatalogTypeEntities.AddAsync(new CatalogTypeEntity() { TypeName = name });

            await _dbContext.SaveChangesAsync();

            return type.Entity.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var typeToDelete = await _dbContext.CatalogTypeEntities.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (typeToDelete != null)
            {
                _dbContext.CatalogTypeEntities.Remove(typeToDelete);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PaginatedItems<CatalogTypeEntity>> GetTypes(int pageIndex, int pageSize)
        {
            var totalItems = await _dbContext.CatalogTypeEntities
            .LongCountAsync();

            var itemsOnPage = await _dbContext.CatalogTypeEntities
                .OrderBy(c => c.TypeName)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedItems<CatalogTypeEntity>() { TotalCount = totalItems, Data = itemsOnPage };
        }

        public async Task<int?> Update(int id, string newName)
        {
            var typeToUpdate = await _dbContext.CatalogTypeEntities.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (typeToUpdate != null)
            {
                typeToUpdate.TypeName = newName;
                await _dbContext.SaveChangesAsync();
                return typeToUpdate.Id;
            }

            return null;
        }
    }
}
