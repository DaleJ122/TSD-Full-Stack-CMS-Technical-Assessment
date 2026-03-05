namespace TSDTechAssessment2026.API.Models;

public sealed record ProductVariant(
    Guid Id,
    string Name,
    string Sku,
    int Stock,
    decimal Price,
    bool Active);

public sealed record Product(
    Guid Id,
    string Name,
    string Category,
    string Description,
    string Currency,
    string[] Images,
    string Sku,
    string Brand,
    double Rating,
    int ReviewCount,
    bool Active,
    ProductVariant[]? Variants = null,
    decimal? Price = null,
    int? Stock = null);

internal sealed record ProductsFile(Product[] Products);
