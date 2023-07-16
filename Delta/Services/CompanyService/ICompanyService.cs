using Delta.Models;

namespace Delta.Services.CompanyService;

public interface ICompanyService
{
    // Task SaveNewCompanyAsync(ReviewModel company);
    Task<IEnumerable<ReviewModel>> GetApprovedCompaniesAsync();
}