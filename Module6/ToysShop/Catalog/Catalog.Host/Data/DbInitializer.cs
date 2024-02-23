using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogBrandEntities.Any())
        {
            await context.CatalogBrandEntities.AddRangeAsync(GetPreconfiguredCatalogBrands());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogTypeEntities.Any())
        {
            await context.CatalogTypeEntities.AddRangeAsync(GetPreconfiguredCatalogTypes());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItemEntities.Any())
        {
            await context.CatalogItemEntities.AddRangeAsync(GetPreconfiguredCatalogItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogBrandEntity> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrandEntity>()
    {
        new CatalogBrandEntity() { BrandName = "L.O.L Surprise" },
        new CatalogBrandEntity() { BrandName = "Rainbow High" },
        new CatalogBrandEntity() { BrandName = "Monster High" },
        new CatalogBrandEntity() { BrandName = "Star Wars" },
        new CatalogBrandEntity() { BrandName = "Hot Wheels" },
        new CatalogBrandEntity() { BrandName = "Purse Pets" }
    };
    }

    private static IEnumerable<CatalogTypeEntity> GetPreconfiguredCatalogTypes()
    {
        return new List<CatalogTypeEntity>()
    {
        new CatalogTypeEntity() { TypeName = "Doll"},
        new CatalogTypeEntity() { TypeName = "Interactive toy"},
        new CatalogTypeEntity() { TypeName = "Handbags"},
        new CatalogTypeEntity() { TypeName = "Track"}
    }; 
    }

    private static IEnumerable<CatalogItemEntity> GetPreconfiguredCatalogItems()
    {
        return new List<CatalogItemEntity>()
    {
         new CatalogItemEntity() { CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 10, Description = "L.O.L. Surprise Tweens Series 4 Fashion Doll Jenny Rox", Name = "Fashion Doll Jenny Rox", Price = 800, PictureFileName = "1.png" },
         new CatalogItemEntity() { CatalogTypeId = 1, CatalogBrandId = 2, AvailableStock = 11, Description = "Rainbow High Shadow High Lavender Purple Fashion", Name = "Lavender Purple Fashion Doll", Price = 1125, PictureFileName = "2.png" },
         new CatalogItemEntity() { CatalogTypeId = 1, CatalogBrandId = 3, AvailableStock = 15, Description = "Monster High Doll Clawd Wolf Werewolf with Pet", Name = "Clawd Wolf Werewolf with Pet", Price = 1300, PictureFileName = "3.png" },
         new CatalogItemEntity() { CatalogTypeId = 2, CatalogBrandId = 4, AvailableStock = 6, Description = "Star Wars Grogu Animatronic Mandalorian", Name = "Baby Yoda", Price = 1850, PictureFileName = "4.png" },
         new CatalogItemEntity() { CatalogTypeId = 1, CatalogBrandId = 1, AvailableStock = 17, Description = "L.O.L Surprise OMG Sunshine Color Change Switches", Name = "Sunshine Color Change Switches Doll", Price = 900, PictureFileName = "5.png" },
         new CatalogItemEntity() { CatalogTypeId = 2, CatalogBrandId = 4, AvailableStock = 32, Description = "Star Wars Grogu Baby Yoda from The Mandalorian", Name = "Baby Yoda", Price = 2395, PictureFileName = "6.png" },
         new CatalogItemEntity() { CatalogTypeId = 3, CatalogBrandId = 6, AvailableStock = 11, Description = "Purse Pets Hello Kitty Interactive Shoulder Bag", Name = "Hello Kitty Interactive Shoulder Bag", Price = 1000, PictureFileName = "7.png" },
         new CatalogItemEntity() { CatalogTypeId = 3, CatalogBrandId = 6, AvailableStock = 5, Description = "Purse Pets Holly Hops Bunny Tote Bag Interactive Pet", Name = "Holly Hops Bunny Tote Bag", Price = 900, PictureFileName = "8.png" },
         new CatalogItemEntity() { CatalogTypeId = 4, CatalogBrandId = 5, AvailableStock = 9, Description = "Hot Wheels Corkscrew Crash Track Set FTB65", Name = "Corkscrew Crash Track Set FTB65", Price = 2600, PictureFileName = "9.png" },
         new CatalogItemEntity() { CatalogTypeId = 4, CatalogBrandId = 5, AvailableStock = 12, Description = "Hot Wheels Track Builder Infinity Loop Kit Mattel GVG10 ", Name = "Infinity Loop Kit Mattel GVG10", Price = 2000, PictureFileName = "10.png" },
    };
    }
}
