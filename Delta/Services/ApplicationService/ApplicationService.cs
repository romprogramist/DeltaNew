using Delta.Data;
using Delta.Models;

namespace Delta.Services.ApplicationService;

public class ApplicationService : IApplicationService
{
    private readonly DeltaDbContext _context;
    
    public ApplicationService(DeltaDbContext context)
    {
        _context = context;
    }
    
    public async Task SaveApplicationAsync(ApplicationModel application)
    {
        _context.ClientApplications.Add(new ClientApplication
        {
            CreationDateTime = DateTime.Now.ToUniversalTime(),
            Name = application.Name,
            Phone = application.Phone,
            SitePage = application.SitePage,
            AdditionalInfo = application.AdditionalInfo,
            UtmInfo = application.UtmInfo,
        });
    
        await _context.SaveChangesAsync();
    }
}