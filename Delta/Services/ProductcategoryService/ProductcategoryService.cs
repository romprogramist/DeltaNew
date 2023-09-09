using Delta.Data;
using Delta.Helpers;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ProductcategoryService;

public class ProductcategoryService : IProductcategoryService
{
    private readonly DeltaDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ProductcategoryService(DeltaDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }


    public async Task<string> SaveProductcategoryImageAsync(IFormFile file)
    {
        var uniqueFileName = FileHelper.GetUniqueFileName(file.FileName);
        var uploadDirectory = Path.Combine(_environment.WebRootPath, "images", "reagents");
        var filePath = Path.Combine(uploadDirectory, uniqueFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException());
        await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
        return uniqueFileName;
    }

    public async Task<bool> AddProductcategoryAsync(ProductcategoryDto productcategory)
    {
        // var parentCategoryId = await _context.Products
        // .Where(rc => productcategory.ParentCategoryId.Contains(rc.Id)).ToListAsync();
        
        _context.ProductCategories.Add(new ProductCategory
        {
            Name = productcategory.Name,
            Image = productcategory.Image,
            Url = productcategory.Url,
            ParentCategoryId = productcategory.ParentCategoryId
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }

    public async Task<List<ProductcategoryDto>> GetProductcategorysAsync()
    {
        return await _context.ProductCategories
            .Select(c => new ProductcategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Url = c.Url,
                ParentCategoryId = c.ParentCategoryId.HasValue ? c.ParentCategoryId.Value : 0
            }).ToListAsync();
    }

    public async Task<ProductcategoryDto?> GetProductcategoryAsync(int id)
    {
        var productCategory = await _context.ProductCategories
            .Where(p => p.Id == id)
            .Select(p => new ProductcategoryDto
            {
                Id = p.Id,
                Name = p.Name,
                Image = p.Image,
                Url = p.Url,
                ParentCategoryId = p.ParentCategoryId.HasValue ? p.ParentCategoryId.Value : 0
            }).FirstOrDefaultAsync();

        if (productCategory != null && productCategory.ParentCategoryId > 0)
        {
            var parentCategoryName = await _context.ProductCategories
                .Where(p => p.Id == productCategory.ParentCategoryId)
                .Select(p => p.Name)
                .FirstOrDefaultAsync();

            if (!string.IsNullOrEmpty(parentCategoryName))
            {
                productCategory.ParentCategoryName = parentCategoryName;
            }
        }

        return productCategory;
    }

    public Task<ProductcategoryDto?> UpdateProductcategoryAsync(ProductcategoryDto productcategoryDto)
    {
        throw new NotImplementedException();
    }
}