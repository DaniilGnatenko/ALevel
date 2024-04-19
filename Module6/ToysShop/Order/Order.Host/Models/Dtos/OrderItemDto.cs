namespace Order.Host.Models.Dtos;

public class OrderItemDto
{
    public int ItemId { get; set; }
    public string Name { get; set; } = null!;
    public int PricePerOne { get; set; }
    public int Amount { get; set; }
}
