using Delta.Models.Dtos;

namespace Delta.Services.ProductcategoryService;

public interface IProductcategoryService
{
    Task<string> SaveProductcategoryImageAsync(IFormFile requestFile);
    Task<bool> AddProductcategoryAsync(ProductcategoryDto productcategory);
    Task<List<ProductcategoryDto>> GetProductcategorysAsync();
    Task<ProductcategoryDto?> GetProductcategoryAsync(int id);
    Task<ProductcategoryDto?> UpdateProductcategoryAsync(ProductcategoryDto productcategory);
    Task<bool> DeleteReagentcategoryAsync(int id);
}
