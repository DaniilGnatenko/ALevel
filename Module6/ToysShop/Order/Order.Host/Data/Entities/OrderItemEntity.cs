namespace Order.Host.Data.Entities;

public class OrderItemEntity
{
    public int Id { get; set; }
    public int CatalogItemId { get; set; }
    public string Name { get; set; } = null!;
    public int PricePerItem { get; set; }
    public int Amount { get; set; }
    public int OrderId { get; set; }
    public OrderEntity Order { get; set; }
}
