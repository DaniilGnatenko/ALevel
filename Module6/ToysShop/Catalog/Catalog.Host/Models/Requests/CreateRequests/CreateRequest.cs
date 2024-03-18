using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CreateRequests;

public class CreateRequest
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
}
