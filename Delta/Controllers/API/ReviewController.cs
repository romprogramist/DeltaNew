using Delta.Models;
using Delta.Services.ReviewService;
using Microsoft.AspNetCore.Mvc;
namespace Delta.Controllers.API;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly IReviewService _reviewService;
    
    public ReviewController(IReviewService reviewService)
    {
        _reviewService = reviewService;
    }
    
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendReview(ReviewModel review)
    {
        // await _reviewService.SaveNewReviewAsync(review);
        return Ok();
    }
    
    [HttpGet]
    [Route("approved")]
    public async Task<IActionResult> GetReviews()
    {
        return Ok(); // await _reviewService.GetApprovedReviewsAsync()
    }
}