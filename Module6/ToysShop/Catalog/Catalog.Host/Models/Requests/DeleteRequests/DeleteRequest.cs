using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.DeleteRequests
{
    public class DeleteRequest
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
    }
}
