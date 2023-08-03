using Delta.Data;
using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.CertificatesService;

public class CertificateService : ICertificateService
{
    private readonly DeltaDbContext _context;
    
    public CertificateService(DeltaDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IEnumerable<CertificateModel>> GetCertificatesAsync()
    {
        return await _context.Certificates
            .Select(r => new CertificateModel
            {
                Id = r.Id,
                Pdf = r.Pdf,
                Image = r.Image
            }).ToListAsync();
    }
    
    
    
    public async Task<bool> AddCertificateAsync(CertificateModel certificate)
    {
        _context.Certificates.Add(new Certificate
        {
            Id = certificate.Id,
            Pdf = certificate.Pdf,
            Image = certificate.Image
        });
    
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
    public async Task<bool> DeleteCertificateAsync(int id)
    {
        var certificate = await _context.Certificates.FindAsync(id);
        if (certificate is null)
            return false;
    
        _context.Certificates.Remove(certificate);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }
    
}