namespace MVC.ViewModels
{
    public class Basket
    {
        public int TotalCount { get; set; }
        public int TotalPrice { get; set; }
        public List<CatalogItem>? Items { get; set; }
    }
}
