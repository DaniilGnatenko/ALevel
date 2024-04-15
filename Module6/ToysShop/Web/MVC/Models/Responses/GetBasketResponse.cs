using MVC.ViewModels;

namespace MVC.Models.Responses
{
    public class GetBasketResponse
    {
        public List<OrderItem>? Items { get; set; }
    }
}
