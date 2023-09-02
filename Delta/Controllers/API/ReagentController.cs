using Delta.Models;
using Delta.Models.Dtos;
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
    // [Authorize(Roles = "Admin")]  
    public async Task<IActionResult> AddReagent([FromForm] ReagentModel reagent)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            if (requestFiles[0].Length > 1024 * 1024)
            {
                return BadRequest("File size is too large.");
            }
            reagent.InstructionPdf = await _reagentService.SaveReagentImageAsync(requestFiles[0]);
        }
        
        var reagentDto = new ReagentDto
        {
            Name = reagent.Name,
            KitComposition = reagent.KitComposition,
            ReagentCategoryIds = reagent.ReagentCategoryIds,
            InstructionPdf = reagent.InstructionPdf,
            CompanyId = reagent.CompanyId
        };
        
        
        
        var saved = await _reagentService.AddReagentAsync(reagentDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    [HttpPost]
    [Route("update")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateReagent([FromForm] ReagentModel reagent)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            if (requestFiles[0].Length > 1024 * 1024)
            {
                return BadRequest("File size is too large.");
            }
            reagent.InstructionPdf = await _reagentService.SaveReagentImageAsync(requestFiles[0]);
        }
        
        else
        {
            reagent.InstructionPdf = string.Empty;
        }
        
        var reagentDto = new ReagentDto
        {
            Id = reagent.Id,
            Name = reagent.Name,
            KitComposition = reagent.KitComposition,
            // ReagentCategoryNames = reagent.ReagentCategoryNames,
            CompanyId = reagent.CompanyId,
            ReagentCategoryIds = reagent.ReagentCategoryIds,
            InstructionPdf = reagent.InstructionPdf
        };
        
        var savedReagent = await _reagentService.UpdateReagentAsync(reagentDto);
        if(savedReagent == null)
            return BadRequest("Failed to save the object");
        
        var reagentModel = new ReagentModel
        {
            Id = reagent.Id,
            Name = savedReagent.Name,
            KitComposition = savedReagent.KitComposition,
            // ReagentCategoryNames = reagent.ReagentCategoryNames,
            CompanyId = savedReagent.CompanyId,
            ReagentCategoryIds = savedReagent.ReagentCategoryIds,
            InstructionPdf = savedReagent.InstructionPdf
        };
        
        return Ok(reagentModel);
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteReagent(int id)
    {
        var deleted = await _reagentService.DeleteReagentAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
    [HttpGet]
    [Route("getByCategory")]
    public async Task<IActionResult> GetReagentsByCategory([FromQuery] int[] categoryIds)
    {
        var reagents = await _reagentService.GetReagentsByCategoryAsync(categoryIds);
        return Ok(reagents);
    }
    
}