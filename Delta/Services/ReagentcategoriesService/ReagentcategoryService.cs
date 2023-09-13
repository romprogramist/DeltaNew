using Delta.Data;
using Delta.Models;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ReagentcategoryService;

public class ReagentcategoryService : IReagentcategoryService
{
    private readonly DeltaDbContext _context;
    
    public ReagentcategoryService(DeltaDbContext context)
    {
        _context = context;
    }


    public async Task<bool> AddReagentcategory(ReagentCategoryDto reagentCategory)
    {
        _context.ReagentCategories.Add(new ReagentCategory
        {
            Name = reagentCategory.Name
        });
    
        var savedCount = await _context.SaveChangesAsync();
    
        return savedCount > 0;
    }

    public async Task<bool> AddReagentcategoryAsync(ReagentCategoryDto reagentCategory)
    {
        _context.ReagentCategories.Add(new ReagentCategory
        {
            Name = reagentCategory.Name
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    public async Task<IEnumerable<ReagentCategoryDto>> GetReagentcategoriesAsync(int? categoryId = null)
    {
        return await _context.ReagentCategories
            .Where(p => categoryId == null || p.Id == categoryId)
            // .Include(p => p.Category)
            .Select(p => new ReagentCategoryDto
            {
                Id = p.Id,
                Name = p.Name
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

    public async Task<ReagentCategoryDto?> GetReagentcategoryAsync(int id)
    {
        return await _context.ReagentCategories
            .Where(p => p.Id == id)
            // .Include(p => p.Category)
            .Select(p => new ReagentCategoryDto
            {
                Id = p.Id,
                Name = p.Name
            }).FirstOrDefaultAsync();
    }

    public async Task<ReagentCategoryDto?> UpdateReagentcategoryAsync(ReagentCategoryDto reagentCategory)
    {
        var reagentcategoryToUpdate = await _context.ReagentCategories.FindAsync(reagentCategory.Id);
        if (reagentcategoryToUpdate is null)
            return null;
        
        reagentcategoryToUpdate.Name = reagentCategory.Name;
        _context.ReagentCategories.Update(reagentcategoryToUpdate);
        
        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        var reagentcategoryDto = new ReagentCategoryDto
        {
            Id = reagentcategoryToUpdate.Id,
            Name = reagentcategoryToUpdate.Name
        };

        return reagentcategoryDto;
    }
}