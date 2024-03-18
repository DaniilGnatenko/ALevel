using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests;

public class PaginatedItemsWithIdRequest
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [Range(0, int.MaxValue)]
    public int PageIndex { get; set; }
    [Required]
    [Range(0, 50)]
    public int PageSize { get; set; }
}
