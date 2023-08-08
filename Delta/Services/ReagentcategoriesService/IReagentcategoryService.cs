using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.ReagentcategoryService;

public interface IReagentcategoryService
{
    Task<IEnumerable<ReagentcategoryDto>> GetReagentcategoriesAsync(int? categoryId = null);
    Task<bool> AddReagentcategoryAsync(ReagentcategoryDto reagentcategory);
    Task<bool> DeleteReagentcategoryAsync(int id);
    
    Task<ReagentcategoryDto?> GetReagentcategoryAsync(int id);
    Task<ReagentcategoryDto?> UpdateReagentcategoryAsync(ReagentcategoryDto reagentcategory);
}