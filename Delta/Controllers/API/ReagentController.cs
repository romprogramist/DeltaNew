using Delta.Models;
using Delta.Services.ReagentService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Delta.Controllers.API;


[ApiController]
[Route("api/reagents")]
public class ReagentController : ControllerBase
{
    private readonly IReagentService _reagentService;

    public ReagentController(IReagentService reagentService)
    {
        _reagentService = reagentService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetReagents()
    {
        var reagents = await _reagentService.GetReagentsAsync();
        return Ok(reagents);
    }
    
    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddReagent(ReagentModel reagent)
    {
        var saved = await _reagentService.AddReagentAsync(reagent);
        if(!saved)
            return BadRequest();
        return Ok();
    }
}