using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.CompanyService;

public class CompanyService : ICompanyService
{
    private readonly DeltaDbContext _context;
    
    public CompanyService(DeltaDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<bool> AddCompanyAsync(CompanyModel company)
    {
        _context.Companies.Add(new Company
        {
            Name = company.Name,
            Description = company.Description,
            Logo = company.Logo
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    public async Task<IEnumerable<CompanyModel>> GetCompaniesAsync()
    {
        return await _context.Companies
            .Select(r => new CompanyModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                Logo = r.Logo
            }).ToListAsync();
    }
    
    public async Task<bool> DeleteCompanyAsync(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company is null)
            return false;
    
        _context.Companies.Remove(company);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
}









