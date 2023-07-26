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
}