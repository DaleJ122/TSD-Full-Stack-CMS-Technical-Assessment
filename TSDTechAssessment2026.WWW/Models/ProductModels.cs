namespace TSDTechAssessment2026.WWW.Models;

public sealed record ProductVariantDto(
    Guid Id,
    string Name,
    string Sku,
    int Stock,
    decimal Price,
    bool Active);

public sealed record ProductDto(
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
    ProductVariantDto[]? Variants = null,
    decimal? Price = null,
    int? Stock = null)
{
    public decimal DisplayPrice
    {
        get
        {
            if (Price.HasValue)
                return Price.Value;

            if (Variants is { Length: > 0 })
            {
                var activePrices = Variants.Where(v => v.Active).Select(v => v.Price).ToArray();
                if (activePrices.Length > 0)
                    return activePrices.Min();

                return Variants.Min(v => v.Price);
            }

            return 0;
        }
    }

    public bool HasVariantPricing =>
        !Price.HasValue && Variants is { Length: > 0 }
        && Variants.Where(v => v.Active).Select(v => v.Price).Distinct().Count() > 1;

    public bool IsOutOfStock
    {
        get
        {
            if (!Active) return true;
            if (Variants is { Length: > 0 })
                return !Variants.Any(v => v.Active && v.Stock > 0);
            return Stock is 0;
        }
    }

    public int TotalStock
    {
        get
        {
            if (Variants is { Length: > 0 })
                return Variants.Where(v => v.Active).Sum(v => v.Stock);
            return Stock ?? 0;
        }
    }

    public int ActiveVariantCount =>
        Variants?.Count(v => v.Active) ?? 0;
}
