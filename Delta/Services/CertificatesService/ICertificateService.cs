using Delta.Models;

namespace Delta.Services.CertificatesService;

public interface ICertificateService
{
    Task<bool> AddCertificateAsync(CertificateModel certificate);
    Task<IEnumerable<CertificateModel>> GetCertificatesAsync();
    Task<bool> DeleteCertificateAsync(int id);
}