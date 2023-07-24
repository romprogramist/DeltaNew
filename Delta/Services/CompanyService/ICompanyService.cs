using Delta.Data;
using Delta.Models;

namespace Delta.Services.CompanyService;

public interface ICompanyService
{
    Task<bool> AddCompanyAsync(CompanyModel company);
    Task<IEnumerable<CompanyModel>> GetCompaniesAsync();
    Task<bool> DeleteCompanyAsync(int id);
}