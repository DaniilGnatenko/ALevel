namespace MVC.Models.Requests
{
	public class ItemIdRequest
	{
		[Required]
		[Range(1, int.MaxValue)]
		public int ItemId { get; set; }
	}
}
