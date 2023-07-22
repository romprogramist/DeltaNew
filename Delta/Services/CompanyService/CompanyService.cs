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
    
    
    public async Task SaveNewCompanyAsync(CompanyModel company)
    {
        _context.Companies.Add(new Company
        {
            Name = company.Name,
            Description = company.Description,
            Logo = company.iFormFile
        });
    
        await _context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<CompanyModel>> GetApprovedCompaniesAsync()
    {
        return await _context.Companies
            .Select(r => new CompanyModel
            {
                Name = r.Name,
                Description = r.Description,
                iFormFile = r.Logo,
                id = r.Id
            }).ToListAsync();
    }
    
    public async Task<List<Company>> DeleteCompany(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company is null)
            return null;
    
        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();
    
        return await _context.Companies.ToListAsync();
    }
    
}









