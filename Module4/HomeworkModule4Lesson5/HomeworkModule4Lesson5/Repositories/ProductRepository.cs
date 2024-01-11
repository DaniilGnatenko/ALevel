using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<int> AddProductAsync(string name, double price)
    {
        var product = new ProductEntity()
        {
            Name = name,
            Price = price
        };

        var result = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }


    public async Task<ProductEntity?> GetProductAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<int> UpdateProductAsync(int id, double price)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

        if (product == null)
        {
            return id;
        }

        product.Price = price;

        await _dbContext.SaveChangesAsync();

        return product.Id;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);

        if (product == null)
        {
            return false;
        }

        _dbContext.Products.Remove(product);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IList<ProductEntity>> GetPaginatedProductsAsync(int pageIndex, double price)
    {
        return await _dbContext.Products
            .Where(x => x.Price >= price)
            .Skip(pageIndex * 20)
            .Take(20)
            .OrderByDescending(x => x.Price)
            .ToListAsync();
    }
}