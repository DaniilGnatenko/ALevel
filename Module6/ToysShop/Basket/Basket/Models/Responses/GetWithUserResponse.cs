namespace Basket.Models.Responses
{
	public class GetWithUserResponse
	{
		public List<Item> Items { get; set; }
		public string UserKey { get; set; }
	}
}
