﻿namespace Catalog.Host.Data.Entities;

public class CatalogItemEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string PictureFileName { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrandEntity CatalogBrand { get; set; }
    public int CatalogTypeId { get; set; }
    public CatalogTypeEntity CatalogType { get; set; }
    public int AvailableStock { get; set; }
}
