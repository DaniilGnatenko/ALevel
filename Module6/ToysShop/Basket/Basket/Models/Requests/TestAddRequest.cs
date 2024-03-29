using System.ComponentModel.DataAnnotations;

namespace Basket.Models.Requests
{
    public class TestAddRequest
    {
        [Required]
        public string Data { get; set; } = null!;
    }
}
