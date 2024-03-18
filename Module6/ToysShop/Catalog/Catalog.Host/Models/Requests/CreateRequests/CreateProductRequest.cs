using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CatalogProductRequests;

public class CreateProductRequest
{
    [Required]
    [MaxLength(75)]
    public string Name { get; set; } = null!;
    [MaxLength(200)]
    public string Description { get; set; } = null!;
    [Required]
    [Range(0, int.MaxValue)]
    public int Price { get; set; }
    [MaxLength(100)]
    public string PictureFileName { get; set; } = null!;
    [Required]
    [Range(1, int.MaxValue)]
    public int CatalogBrandId { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int CatalogTypeId { get; set; }
    [Range(0, int.MaxValue)]
    public int AvailableStock { get; set; }
}