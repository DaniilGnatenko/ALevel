namespace MVC.ViewModels
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalPrice { get; set; }
        public string UserId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
