using Delta.Models;
using Delta.Services.CompanieService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;


[ApiController]
[Route("api/companie")]
public class CompanieController : ControllerBase
{
    private readonly ICompanieService _companieService;

    public CompanieController(ICompanieService companieService)
    {
        _companieService = companieService;
    }
    
    
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendCompanie(ReviewModel review)
    {
        await _companieService.SaveNewCompanieAsync(review);
        return Ok();
    }
    
    [HttpGet]
    [Route("approved")]
    public async Task<IActionResult> GetCompanie()
    {
        return Ok(await _companieService.GetApprovedCompanieAsync());
    }
}