using TSDTechAssessment2026.WWW.Models;

namespace TSDTechAssessment2026.WWW.Services;

public sealed class ProductApiClient(HttpClient http)
{
    public async Task<List<ProductDto>> FetchProductsAsync(string? category = null)
    {
        var url = "/products";
        if (!string.IsNullOrWhiteSpace(category))
            url += $"?category={Uri.EscapeDataString(category)}";

        var products = await http.GetFromJsonAsync<List<ProductDto>>(url);
        return products ?? [];
    }
}
