using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ReagentcategoryService;

public class ReagentcategoryService : IReagentcategoryService
{
    private readonly DeltaDbContext _context;
    
    public ReagentcategoryService(DeltaDbContext context)
    {
        _context = context;
    }

    
    public async Task<bool> AddReagentcategoryAsync(ReagentcategoryModel reagentcategory)
    {
        _context.ReagentCategories.Add(new ReagentCategory
        {
            Name = reagentcategory.Name
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    
    public async Task<IEnumerable<ReagentcategoryModel>> GetReagentcategoriesAsync()
    {
        return await _context.ReagentCategories
            .Select(r => new ReagentcategoryModel
            {
                Id = r.Id,
                Name = r.Name
            }).ToListAsync();
    }
    
    
    
    public async Task<bool> DeleteReagentcategoryAsync(int id)
    {
        var reagentcategory = await _context.ReagentCategories.FindAsync(id);
        if (reagentcategory is null)
            return false;
    
        _context.ReagentCategories.Remove(reagentcategory);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    
}