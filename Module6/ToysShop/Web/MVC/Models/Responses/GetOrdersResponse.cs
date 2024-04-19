using MVC.ViewModels;

namespace MVC.Models.Responses
{
	public class GetOrdersResponse
	{
		public List<Order>? Orders { get; set; }
	}
}
