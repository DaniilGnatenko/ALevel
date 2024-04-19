using MVC.ViewModels;

namespace MVC.Models.Responses
{
	public class GetBasketWithUserResponse
	{
		public List<OrderItem>? Items { get; set; }
		public string? UserKey { get; set; }
	}
}
