using Infrastructure.Identity;

namespace MVC;

public class AppSettings
{
    public string CatalogUrl { get; set; }
    public string CatalogItemUrl { get; set; }
    public string BasketBffUrl { get; set; }
    public string BasketItemUrl { get; set; }
    public string OrderBffUrl { get; set; }
    public string OrderUrl { get; set; }
    public int SessionCookieLifetimeMinutes { get; set; }
    public string CallBackUrl { get; set; }
    public string IdentityUrl { get; set; }
}
