namespace MVC.Models.Requests
{
    public class ItemRequest
    {
		[Required]
		[Range(1, int.MaxValue)]
		public int ItemId { get; set; }
		[Required]
		public string Name { get; set; } = null!;
		[Required]
		[Range(1, int.MaxValue)]
		public int PricePerOne { get; set; }
    }
}
