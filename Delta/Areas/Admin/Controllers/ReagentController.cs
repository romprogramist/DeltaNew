using Delta.Models;
using Delta.Services.ReagentService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ReagentController : BaseAdminController
{
    
    private readonly IReagentService _reagentService;
    
    public ReagentController(IReagentService reagentService)
    {
        _reagentService = reagentService;
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
        var reagent = await _reagentService.GetReagentAsync(id);
        
        if(reagent == null)
            return NotFound("Reagent not found.");
        
        var reagentModel = new ReagentModel
        {
            Id = reagent.Id,
            Name = reagent.Name,
            InstructionPdf = reagent.InstructionPdf,
            CompanyId = reagent.CompanyId,
            CompanyName = reagent.CompanyName
        };
        
        
        return View(reagentModel);
    }
}