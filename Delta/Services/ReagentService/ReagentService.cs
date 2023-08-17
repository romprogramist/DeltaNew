using Delta.Data;
using Delta.Helpers;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ReagentService;

public class ReagentService : IReagentService
{
    private readonly DeltaDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ReagentService(DeltaDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }
    
    public async Task<string> SaveReagentImageAsync(IFormFile file)
    {
        var uniqueFileName = FileHelper.GetUniqueFileName(file.FileName);
        var uploadDirectory = Path.Combine(_environment.WebRootPath, "images", "reagents");
        var filePath = Path.Combine(uploadDirectory, uniqueFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException());
        await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
        return uniqueFileName;
    }
    
    public async Task<bool> AddReagentAsync(ReagentDto reagent)
    {
        var reagentCategories = await _context.ReagentCategories
            .Where(rc => reagent.ReagentCategoryIds.Contains(rc.Id)).ToListAsync();
        
        _context.Reagents.Add(new Reagent
        {
            Name = reagent.Name,
            KitComposition = reagent.KitComposition,
            InstructionPdf = reagent.InstructionPdf,
            CompanyId = reagent.CompanyId,
            ReagentCategories = reagentCategories
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }

    public async Task<List<ReagentDto>> GetReagentsAsync()
    {
        return await _context.Reagents
            .Select(r => new ReagentDto
            {
                Id = r.Id,
                Name = r.Name,
                KitComposition = r.KitComposition,
                InstructionPdf = r.InstructionPdf,
                CompanyId = r.CompanyId,
                CompanyName = r.Company.Name
            }).ToListAsync();
    }
    
    public async Task<bool> DeleteReagentAsync(int id)
    {
        var reagent = await _context.Reagents
            .Include(r => r.ReagentCategories)
            .FirstOrDefaultAsync(r => r.Id == id);
        if (reagent is null)
            return false;

        var reagentCategories = await _context.ReagentCategories
            .Where(rc => reagent.ReagentCategories.Contains(rc)).ToListAsync();
        
        foreach (var reagentCategory in reagentCategories)
        {
            reagent.ReagentCategories.Remove(reagentCategory);
        }

        _context.Reagents.Remove(reagent);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    
    public async Task<ReagentDto?> GetReagentAsync(int id)
    {
        return await _context.Reagents
            .Include(p => p.Company)
            .Where(p => p.Id == id)
            .Select(p => new ReagentDto
            {
                Id = p.Id,
                Name = p.Name,
                KitComposition = p.KitComposition,
                InstructionPdf = p.InstructionPdf,
                CompanyId = p.CompanyId,
                CompanyName = p.Company.Name
            }).FirstOrDefaultAsync();
    }
    
}