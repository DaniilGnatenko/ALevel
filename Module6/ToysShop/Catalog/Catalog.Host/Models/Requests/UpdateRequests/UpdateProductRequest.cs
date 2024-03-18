using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.UpdateRequests
{
    public class UpdateProductRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [MaxLength(75)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Range(0, int.MaxValue)]
        public int Price { get; set; }
        [MaxLength(100)]
        public string PictureFileName { get; set; }
        [Range(1, int.MaxValue)]
        public int CatalogBrandId { get; set; }
        [Range(1, int.MaxValue)]
        public int CatalogTypeId { get; set; }
        [Range(0, int.MaxValue)]
        public int AvailableStock { get; set; }
    }
}
