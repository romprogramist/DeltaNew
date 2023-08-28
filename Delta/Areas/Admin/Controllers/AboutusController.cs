
using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.Aboutus;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class AboutusController : BaseAdminController
{
    private readonly IAboutusService _aboutusService;
    
    public AboutusController(IAboutusService aboutusService)
    {
        _aboutusService = aboutusService;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    
    public IActionResult Add()
    {
        return View();
    }
    
    public async Task<IActionResult> Edit(int id)
    {
        var aboutus = await _aboutusService.GetAboutusAsync(id);
        
        
        if(aboutus == null)
            return NotFound("Company not found.");
        
        var aboutusModel = new AboutusModel
        {
            Id = aboutus.Id,
            Title = aboutus.Title
        };
        return View(aboutusModel);
    }
}