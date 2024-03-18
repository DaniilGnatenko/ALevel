using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.CatalogBrandRequests
{
    public class UpdateRequest
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string NewName { get; set; }
    }
}
