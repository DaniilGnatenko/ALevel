namespace Order.Host.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalPrice { get; set; }
        public string UserID { get; set; }
        public List<OrderItemEntity> Items { get; set; } = null!;
    }
}
