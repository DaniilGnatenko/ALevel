namespace Catalog.Host.Models.Requests.UpdateRequests
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string PictureFileName { get; set; }
        public int CatalogBrandId { get; set; }
        public int CatalogTypeId { get; set; }
    }
}
