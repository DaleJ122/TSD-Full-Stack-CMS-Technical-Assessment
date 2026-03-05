using Microsoft.AspNetCore.Mvc;
using TSDTechAssessment2026.WWW.Services;

namespace TSDTechAssessment2026.WWW.ViewComponents;

public class ProductCatalogueViewComponent(ProductApiClient api) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(
        string? heading = null,
        string? category = null,
        int? maxItems = null,
        int? perPage = null)
    {
        List<Models.ProductDto> products;

        try
        {
            products = await api.FetchProductsAsync(category);
        }
        catch (HttpRequestException)
        {
            products = [];
        }

        if (maxItems is > 0)
            products = products.Take(maxItems.Value).ToList();

        ViewBag.Heading = heading;
        ViewBag.PerPage = perPage is > 0 ? perPage.Value : 0;
        return View(products);
    }
}
