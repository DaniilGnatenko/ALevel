using ALevelSample.Data.Entities;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IProductService
{
    Task<int> AddProductAsync(string name, double price);
    Task<Product> GetProductAsync(int id);
    Task<int> UpdateProductAsync(int id, double price);
    Task<bool> DeleteProductAsync(int id);
    Task<IList<ProductEntity>> GetPaginatedProductsAsync(int pageIndex, double price);
}