namespace Basket.Models.Dtos
{
    public class CatalogItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PictureUrl { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public CatalogType CatalogType { get; set; }
        public int AvailableStock { get; set; }
    }
}
