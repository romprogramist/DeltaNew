using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ReagentService;

public class ReagentService : IReagentService
{
    private readonly DeltaDbContext _context;
    
    public ReagentService(DeltaDbContext context)
    {
        _context = context;
    }
    
    public async Task<bool> AddReagentAsync(ReagentModel reagent)
    {
        _context.Reagents.Add(new Reagent
        {
            Name = reagent.Name,
            CompanyId = reagent.CompanyId
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }

    public async Task<IEnumerable<ReagentModel>> GetReagentsAsync()
    {
        return await _context.Reagents
            .Select(r => new ReagentModel
            {
                Id = r.Id,
                Name = r.Name,
                CompanyId = r.CompanyId
            }).ToListAsync();
    }
    
    
    public async Task<bool> DeleteReagentAsync(int id)
    {
        var reagent = await _context.Reagents.FindAsync(id);
        if (reagent is null)
            return false;
    
        _context.Reagents.Remove(reagent);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    
}