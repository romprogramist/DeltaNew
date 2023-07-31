using Delta.Models;

namespace Delta.Services.ReagentcategoryService;

public interface IReagentcategoryService
{
    Task<bool> AddReagentcategoryAsync(ReagentcategoryModel reagentcategory);
    Task<IEnumerable<ReagentcategoryModel>> GetReagentcategoriesAsync();
    Task<bool> DeleteReagentcategoryAsync(int id);
}