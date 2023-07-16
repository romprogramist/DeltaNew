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
    
    
    public Task SaveNewCompanyAsync(ReviewModel application)
    {
        throw new NotImplementedException();
    }
    

    public async Task<IEnumerable<ReviewModel>> GetApprovedCompaniesAsync()
    {
        return await _context.Companies
            .Select(r => new ReviewModel
            {
                Name = r.Name
            }).ToListAsync();
    }
}