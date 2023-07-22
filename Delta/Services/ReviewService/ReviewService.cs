using Delta.Models;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ReviewService;

public class ReviewService : IReviewService
{
    // private readonly DataContext _context;
    //
    // public ReviewService(DataContext context)
    // {
    //     _context = context;
    // }
    //
    // public async Task SaveNewReviewAsync(ReviewModel review)
    // {
    //     _context.Reviews.Add(new Review
    //     {
    //         CreationDateTime = DateTime.Now.ToUniversalTime(),
    //         Name = review.Name,
    //         Phone = review.Phone,
    //         Text = review.Text,
    //         Email = review.Email,
    //         SitePage = review.SitePage,
    //         AdditionalInfo = review.AdditionalInfo,
    //         IsApproved = false,
    //         Rate = review.Rate,
    //         UtmInfo = review.UtmInfo,
    //     });
    //
    //     await _context.SaveChangesAsync();
    // }
    //
    // public async Task<IEnumerable<ReviewModel>> GetApprovedReviewsAsync()
    // {
    //     return await _context.Reviews
    //         .Where(r => r.IsApproved)
    //         .Select(r => new ReviewModel
    //         {
    //             Name = r.Name,
    //             Phone = r.Phone,
    //             Email = r.Email,
    //             Text = r.Text,
    //             Rate = r.Rate,
    //             UtmInfo = r.UtmInfo,
    //             SitePage = r.UtmInfo,
    //             AdditionalInfo = r.AdditionalInfo,
    //             IsApproved = r.IsApproved
    //         }).ToListAsync();
    // }
}