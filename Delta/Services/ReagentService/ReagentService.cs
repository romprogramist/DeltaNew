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
                ReagentCategories = r.ReagentCategories,
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
        var reagentDto = await _context.Reagents
            .Include(p => p.Company)
            .Include(p => p.ReagentCategories)
            .Where(p => p.Id == id)
            .Select(p => new ReagentDto
            {
                Id = p.Id,
                Name = p.Name,
                KitComposition = p.KitComposition,
                InstructionPdf = p.InstructionPdf,
                CompanyId = p.CompanyId,
                CompanyName = p.Company.Name,
                ReagentCategoryIds = p.ReagentCategories.Select(rc => rc.Id).ToArray(), // Список Id категорий
                ReagentCategories = p.ReagentCategories // Включение связанных категорий
            }).FirstOrDefaultAsync();

        if (reagentDto != null)
        {
            reagentDto.ReagentCategoryNames = reagentDto.ReagentCategories.Select(rc => rc.Name).ToArray();
        }

        return reagentDto;
    }

   
    
    public async Task<ReagentDto?> UpdateReagentAsync(ReagentDto reagent)
    {
        var reagentToUpdate = await _context.Reagents
            .Include(r => r.ReagentCategories)
            .FirstOrDefaultAsync(r => r.Id == reagent.Id);

        if (reagentToUpdate == null)
            return null;

        reagentToUpdate.Name = reagent.Name;
        reagentToUpdate.CompanyId = reagent.CompanyId;
        reagentToUpdate.InstructionPdf = reagent.InstructionPdf;
        reagentToUpdate.KitComposition = reagent.KitComposition;

        // Удаление старых категорий
        foreach (var oldCategory in reagentToUpdate.ReagentCategories.ToList())
        {
            reagentToUpdate.ReagentCategories.Remove(oldCategory);
        }

        // Добавление новых категорий
        var newCategories = await _context.ReagentCategories
            .Where(rc => reagent.ReagentCategoryIds.Contains(rc.Id))
            .ToListAsync();

        foreach (var newCategory in newCategories)
        {
            reagentToUpdate.ReagentCategories.Add(newCategory);
        }

        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        var reagentDto = new ReagentDto
        {
            Id = reagentToUpdate.Id,
            Name = reagentToUpdate.Name,
            KitComposition = reagentToUpdate.KitComposition,
            InstructionPdf = reagentToUpdate.InstructionPdf
        };

        return reagentDto;
    }
}