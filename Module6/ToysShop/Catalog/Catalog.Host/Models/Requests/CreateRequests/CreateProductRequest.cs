using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Models.Requests.CatalogProductRequests;

public class CreateProductRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int Price { get; set; }
    public string PictureFileName { get; set; } = null!;
    public int CatalogBrandId { get; set; }
    public int CatalogTypeId { get; set; }
    public int AvailableStock { get; set; }
}
