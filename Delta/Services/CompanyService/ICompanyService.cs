using Delta.Models;

namespace Delta.Services.CompanyService;

public interface ICompanyService
{
    Task SaveNewCompanyAsync(CompanyModel company);
    Task<List<CompanyModel>> GetApprovedCompaniesAsync();
}