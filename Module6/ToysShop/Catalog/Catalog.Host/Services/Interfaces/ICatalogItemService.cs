namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(string name, string description, int price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName);
    Task<int?> Update(int id, string name, string description, int price, int catalogBrandId, int catalogTypeId, string pictureFileName, int availableStock);
    Task<bool> Delete(int id);
}
