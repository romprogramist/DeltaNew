using Delta.Data;
using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.CompanyService;


public interface ICompanyService
{
    Task<IEnumerable<CompanyDto>> GetCompaniesAsync(int? categoryId = null);
    Task<bool> AddCompanyAsync(CompanyDto company);
    Task<string> SaveCompanyImageAsync(IFormFile file);
    Task<bool> DeleteCompanyAsync(int id);
    Task<CompanyDto?> GetCompanyAsync(int id);
    Task<CompanyDto?> UpdateCompanyAsync(CompanyDto company);
}