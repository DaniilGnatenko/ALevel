using System.ComponentModel.DataAnnotations;

namespace Order.Host.Models.Requests
{
    public class GetOrdersRequest
    {
        [Required]
        public string? UserKey { get; set; }
    }
}
