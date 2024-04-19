using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Models.Requests.UpdateRequests
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
