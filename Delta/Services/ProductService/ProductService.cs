using Delta.Data;
using Delta.Models.Dtos;

namespace Delta.Services.ProductService;

public class ProductService : IProductService
{
    private readonly DeltaDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ProductService(DeltaDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    public async Task<bool> AddProductAsync(ProductDto product)
    {
        
        _context.Products.Add(new Product
        {
            Model = product.Model,
            Description = product.Description,
            TechInfo = product.TechInfo,
            Url = product.Url,
            ModelSeries = product.ModelSeries,
            Type = product.Type,
            CardTitle = product.CardTitle,
            LongNamePrefix = product.LongNamePrefix,
            CompanyId = product.CompanyId,
            // ProductCategoriesId = product.ProductCategoriesId
        });
        
        var saveCount = await _context.SaveChangesAsync();
        return saveCount > 0;
    }
}