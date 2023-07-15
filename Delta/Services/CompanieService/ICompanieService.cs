using Delta.Models;
namespace Delta.Services.CompanieService;

public interface ICompanieService
{
    Task SaveNewCompanieAsync(ReviewModel application);
    Task<IEnumerable<ReviewModel>> GetApprovedCompanieAsync();
}