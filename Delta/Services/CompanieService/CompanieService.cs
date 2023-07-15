using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.CompanieService;

public class CompanieService : ICompanieService
{
    private readonly DataContext _context;
    
    public CompanieService(DataContext context)
    {
        _context = context;
    }
    public async Task SaveNewCompanieAsync(ReviewModel company)
    {
        // _context.Reviews.Add(new Review
        // {
        //     CreationDateTime = DateTime.Now.ToUniversalTime(),
        //     Name = companie.Name,
        //     Phone = companie.Description,
        //     // Phone = companie.Logo,
        // });
        //
        // await _context.SaveChangesAsync();
    }

    public Task<IEnumerable<ReviewModel>> GetApprovedCompanieAsync()
    {
        throw new NotImplementedException();
    }
}