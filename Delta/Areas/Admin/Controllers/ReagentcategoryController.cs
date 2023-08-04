using Delta.Models;
using Delta.Services.ReagentcategoryService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ReagentcategoryController : BaseAdminController
{
    private readonly IReagentcategoryService _reagentcategoryService;
    
    public ReagentcategoryController(IReagentcategoryService reagentcategoryService)
    {
        _reagentcategoryService = reagentcategoryService;
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
        var reagentcategory = await _reagentcategoryService.GetReagentcategoryAsync(id);
        
        if(reagentcategory == null)
            return NotFound("reagentcategory not found.");
        
        var ReagentcategoryModel = new ReagentcategoryModel
        {
            Id = reagentcategory.Id,
            Name = reagentcategory.Name,
        };
        return View(ReagentcategoryModel);
    }
    
}