using Delta.Models;

namespace Delta.Services.ReviewService;

public interface IReviewService
{
    Task SaveNewReviewAsync(ReviewModel application);
    Task<IEnumerable<ReviewModel>> GetApprovedReviewsAsync();
}