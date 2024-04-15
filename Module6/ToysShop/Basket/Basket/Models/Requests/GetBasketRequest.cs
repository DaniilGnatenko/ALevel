using System.ComponentModel.DataAnnotations;

namespace Basket.Models.Requests
{
    public class GetBasketRequest
    {
		[Required]
		public string UserKey { get; set; } = null!;
    }
}
