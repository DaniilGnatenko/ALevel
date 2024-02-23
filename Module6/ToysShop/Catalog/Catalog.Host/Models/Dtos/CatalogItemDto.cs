namespace Catalog.Host.Models.Dtos;

public class CatalogItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string PictureUrl { get; set; }
    public CatalogBrandDto CatalogBrand { get; set; }
    public CatalogTypeDto CatalogType { get; set; }
    public int AvailableStock { get; set; }
}
