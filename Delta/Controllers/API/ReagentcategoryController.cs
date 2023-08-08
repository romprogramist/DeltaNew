using Delta.Models;
using Delta.Models.Dtos;
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
        return Ok(reagentcategories.Select(p => new ReagentcategoryModel
        {
            Id = p.Id,
            Name = p.Name
        }).OrderBy(p => p.Id));
    }
    
    
    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddReagentcategory(ReagentcategoryModel reagentcategory)
    {
        
        var reagentcategoryDto = new ReagentcategoryDto
        {
            Name = reagentcategory.Name
        };
        var saved = await _reagentcategoryService.AddReagentcategoryAsync(reagentcategoryDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    
    
    [HttpPost]
    [Route("update")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateReagentcategory(ReagentcategoryModel reagentcategory)
    {
        var reagentcategoryDto = new ReagentcategoryDto
        {
            Id = reagentcategory.Id,
            Name = reagentcategory.Name
        };
        var savedReagentcategory = await _reagentcategoryService.UpdateReagentcategoryAsync(reagentcategoryDto);
        if(savedReagentcategory == null)
            return BadRequest();
        
        var reagentcategoryModel = new ReagentcategoryModel
        {
            Id = savedReagentcategory.Id,
            Name = savedReagentcategory.Name
        };
        return Ok(reagentcategoryModel);
    }
    
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteReagentcategory(int id)
    {
        var deleted = await _reagentcategoryService.DeleteReagentcategoryAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
}