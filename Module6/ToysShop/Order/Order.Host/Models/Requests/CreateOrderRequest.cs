using System.ComponentModel.DataAnnotations;
using Order.Host.Models.Dtos;

namespace Order.Host.Models.Requests
{
    public class CreateOrderRequest
    {
		[Required]
		public string? UserKey { get; set; }
		[Required]
		public List<OrderItemDto>? Items { get; set; }
    }
}
