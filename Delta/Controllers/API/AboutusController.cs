using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.Aboutus;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;

[ApiController]
[Route("api/aboutus")]
public class AboutusController : ControllerBase
{
    private readonly IAboutusService _aboutusService;
    
    public AboutusController(IAboutusService aboutusService)
    {
        _aboutusService = aboutusService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetAboutus()
    {
        var aboutus = await _aboutusService.GetAboutusAsync();
        return Ok(aboutus.Select(p => new AboutusModel
        {
            Id = p.Id,
            Title = p.Title
        }).OrderBy(p => p.Id));
    }
    
    
    
    
    [HttpPost]
    [Route("add")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddAboutus(AboutusModel aboutus)
    {
        var aboutusDto = new AboutusDto
        {
            Title = aboutus.Title
        };
        var saved = await _aboutusService.AddAboutusAsync(aboutusDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    
    
    [HttpPost]
    [Route("update")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAboutus(AboutusModel aboutus)
    {
        
        var aboutusDto = new AboutusDto
        {
            Id = aboutus.Id,
            Title = aboutus.Title
        };
        
        var savedAboutus = await _aboutusService.UpdateAboutusAsync(aboutusDto);
        if(savedAboutus == null)
            return BadRequest();
        
        var aboutusModel = new AboutusModel
        {
            Id = savedAboutus.Id,
            Title = savedAboutus.Title
        };
        
        return Ok(aboutusModel);
    }
    
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAboutus(int id)
    {
        var deleted = await _aboutusService.DeleteAboutusAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
    
}