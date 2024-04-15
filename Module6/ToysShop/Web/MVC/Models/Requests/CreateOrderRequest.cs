using MVC.ViewModels;

namespace MVC.Models.Requests
{
    public class CreateOrderRequest
    {
        [Required]
        public string? UserKey { get; set; }
        [Required]
        public List<OrderItem>? Items { get; set; }
    }
}
