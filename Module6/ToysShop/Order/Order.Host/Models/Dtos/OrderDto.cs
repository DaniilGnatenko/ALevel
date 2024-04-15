namespace Order.Host.Models.Dtos;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public int TotalPrice { get; set; }
    public string UserId { get; set; }
    public List<OrderItemDto> Items { get; set; }
}
