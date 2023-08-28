using Delta.Data;
using Delta.Models;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.Aboutus;

public class AboutusService : IAboutusService
{
    private readonly DeltaDbContext _context;
    
    public AboutusService(DeltaDbContext context)
    {
        _context = context;
    }
    
    
    
    public async Task<bool> AddAboutusAsync(AboutusDto aboutus)
    {
        _context.AboutUs.Add(new AboutUs
        {
            Title = aboutus.Title
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }

    public async Task<List<AboutusDto>> GetAboutusAsync()
    {
        
        return await _context.AboutUs
            .Select(r => new AboutusDto
            {
                Id = r.Id,
                Title = r.Title
            }).ToListAsync();
    }
    
    
    public async Task<List<AboutusModel>> GetAllAboutusAsync()
    {
        var aboutus = await _context.AboutUs.ToListAsync();
    
        // Здесь необходимо преобразовать сущности компаний в модели CompanyModel
        var aboutusModel = aboutus.Select(about => new AboutusModel
        {
            Id = about.Id,
            Title = about.Title
        }).ToList();
    
        return aboutusModel;
    }
    
    
    
    public async Task<AboutusDto?> GetAboutusAsync(int id)
    {
        return await _context.AboutUs
            .Where(p => p.Id == id)
            .Select(p => new AboutusDto
            {
                Id = p.Id,
                Title = p.Title
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteAboutusAsync(int id)
    {
        var aboutus = await _context.AboutUs.FindAsync(id);
        if (aboutus is null)
            return false;
    
        _context.AboutUs.Remove(aboutus);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }


    public async Task<AboutusDto?> UpdateAboutusAsync(AboutusDto aboutusDto)
    {
        var aboutusToUpdate = await _context.AboutUs.FindAsync(aboutusDto.Id);
        if (aboutusToUpdate is null)
            return null;
        aboutusToUpdate.Title = aboutusDto.Title;
        _context.AboutUs.Update(aboutusToUpdate);
        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        var companyDto = new AboutusDto
        {
            Id = aboutusToUpdate.Id,
            Title = aboutusToUpdate.Title
        };
        
        return companyDto;
    }
}