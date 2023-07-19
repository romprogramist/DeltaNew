using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.CompanyService;

public class CompanyService : ICompanyService
{
    private readonly DataContext _context;
    
    public CompanyService(DataContext context)
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
                iFormFile = r.Logo
            }).ToListAsync();
    }
}









