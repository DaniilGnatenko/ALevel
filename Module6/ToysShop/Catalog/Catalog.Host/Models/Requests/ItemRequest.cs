using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests
{
    public class ItemRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
    }
}
