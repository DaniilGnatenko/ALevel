using System.ComponentModel.DataAnnotations;

namespace Basket.Models.Requests
{
    public class DeleteItemRequest
    {
		[Required]
		[Range(1, int.MaxValue)]
		public int ItemId { get; set; }
    }
}
