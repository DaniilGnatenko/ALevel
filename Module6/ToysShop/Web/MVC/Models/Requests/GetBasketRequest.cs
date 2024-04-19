namespace MVC.Models.Requests
{
    public class GetBasketRequest
    {
        [Required]
        public string UserKey { get; set; } = null!;
    }
}
