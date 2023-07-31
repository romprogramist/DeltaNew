using Delta.Models;
using Delta.Services.ReagentcategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;


[ApiController]
[Route("api/reagentcategories")]

public class ReagentcategoryController : ControllerBase
{
    private readonly IReagentcategoryService _reagentcategoryService;
    
    
    public ReagentcategoryController(IReagentcategoryService reagentcategoryService)
    {
        _reagentcategoryService = reagentcategoryService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetReagentcategories()
    {
        var reagentcategories = await _reagentcategoryService.GetReagentcategoriesAsync();
        return Ok(reagentcategories);
    }
    
    
    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddReagentcategory(ReagentcategoryModel reagentcategory)
    {
        var saved = await _reagentcategoryService.AddReagentcategoryAsync(reagentcategory);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteReagentcategory(int id)
    {
        var deleted = await _reagentcategoryService.DeleteReagentcategoryAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
}