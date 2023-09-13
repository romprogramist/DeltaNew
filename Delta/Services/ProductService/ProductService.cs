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

    
    public async Task<bool> AddProductAsync(ProductDto productDto)
    {
        var product = new Product
        {
            Model = productDto.Model,
            Description = productDto.Description,
            TechInfo = productDto.TechInfo,
            Url = productDto.Url,
            ModelSeries = productDto.ModelSeries,
            Type = productDto.Type,
            CardTitle = productDto.CardTitle,
            LongNamePrefix = productDto.LongNamePrefix,
            CompanyId = productDto.CompanyId
        };
        
        var productCategory = await _context.ProductCategories.FindAsync(productDto.ProductCategoriesId);

        if (productCategory != null)
        {
            product.ProductCategories = productCategory;
        }
        _context.Products.Add(product);
        
        var saveCount = await _context.SaveChangesAsync();
        return saveCount > 0;
    }
}