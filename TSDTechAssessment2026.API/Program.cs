using System.Text.Json;
using TSDTechAssessment2026.API.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(policy => policy
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.MapOpenApi();

app.UseCors();
app.UseHttpsRedirection();

var productsPath = Path.Combine(app.Environment.ContentRootPath, "data", "products.json");
var jsonOpts = new JsonSerializerOptions(JsonSerializerDefaults.Web);

app.MapGet("/products", async (string? category) =>
{
    var json = await File.ReadAllTextAsync(productsPath);
    var file = JsonSerializer.Deserialize<ProductsFile>(json, jsonOpts);
    var products = file?.Products ?? [];

    if (!string.IsNullOrWhiteSpace(category))
        products = products
            .Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
            .ToArray();

    return Results.Ok(products);
})
.WithName("products");

app.MapGet("/products/{id:guid}", async (Guid id) =>
{
    var json = await File.ReadAllTextAsync(productsPath);
    var file = JsonSerializer.Deserialize<ProductsFile>(json, jsonOpts);
    var product = file?.Products.FirstOrDefault(p => p.Id == id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
})
.WithName("productById");

app.Run();
