using Order.Host.Models.Dtos;

namespace Order.Host.Models.Responses
{
    public class GetOrdersResponse
    {
       public List<OrderDto> Orders { get; set; }
    }
}
