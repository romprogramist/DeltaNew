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


    public async Task<bool> AddReagentcategory(ReagentcategoryDto reagentcategory)
    {
        _context.ReagentCategories.Add(new ReagentCategory
        {
            Name = reagentcategory.Name
        });
    
        var savedCount = await _context.SaveChangesAsync();
    
        return savedCount > 0;
    }

    public async Task<bool> AddReagentcategoryAsync(ReagentcategoryDto reagentcategory)
    {
        _context.ReagentCategories.Add(new ReagentCategory
        {
            Name = reagentcategory.Name
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    public async Task<IEnumerable<ReagentcategoryDto>> GetReagentcategoriesAsync(int? categoryId = null)
    {
        return await _context.ReagentCategories
            .Where(p => categoryId == null || p.Id == categoryId)
            // .Include(p => p.Category)
            .Select(p => new ReagentcategoryDto
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

    public async Task<ReagentcategoryDto?> UpdateReagentcategoryAsync(ReagentcategoryDto reagentcategory)
    {
        var reagentcategoryToUpdate = await _context.ReagentCategories.FindAsync(reagentcategory.Id);
        if (reagentcategoryToUpdate is null)
            return null;
        
        reagentcategoryToUpdate.Name = reagentcategory.Name;
        _context.ReagentCategories.Update(reagentcategoryToUpdate);
        
        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        var reagentcategoryDto = new ReagentcategoryDto
        {
            Id = reagentcategoryToUpdate.Id,
            Name = reagentcategoryToUpdate.Name
        };

        return reagentcategoryDto;
    }
}