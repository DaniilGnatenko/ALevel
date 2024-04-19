namespace MVC.Models.Requests
{
	public class UpdateProductStockRequest
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int Id { get; set; }
		[Range(0, int.MaxValue)]
		public int AvailableStock { get; set; }
	}
}
