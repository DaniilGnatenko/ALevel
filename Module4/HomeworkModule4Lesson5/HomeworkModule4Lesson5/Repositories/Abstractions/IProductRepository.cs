using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IProductRepository
{
    Task<int> AddProductAsync(string name, double price);
    Task<ProductEntity?> GetProductAsync(int id);
    Task<int> UpdateProductAsync(int id, double price);
    Task<bool> DeleteProductAsync(int id);
    Task<IList<ProductEntity>> GetPaginatedProductsAsync(int pageIndex, double price);
}