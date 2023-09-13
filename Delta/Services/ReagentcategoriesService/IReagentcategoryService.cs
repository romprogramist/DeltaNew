using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.ReagentcategoryService;

public interface IReagentcategoryService
{
    Task<IEnumerable<ReagentCategoryDto>> GetReagentcategoriesAsync(int? categoryId = null);
    Task<bool> AddReagentcategoryAsync(ReagentCategoryDto reagentCategory);
    Task<bool> DeleteReagentcategoryAsync(int id);
    
    Task<ReagentCategoryDto?> GetReagentcategoryAsync(int id);
    Task<ReagentCategoryDto?> UpdateReagentcategoryAsync(ReagentCategoryDto reagentCategory);
}