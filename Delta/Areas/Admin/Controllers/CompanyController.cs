using Microsoft.AspNetCore.Mvc;
using Delta.Models;
using Delta.Services.CompanyService;


namespace Delta.Areas.Admin.Controllers;

public class CompanyController : BaseAdminController
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
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
        var company = await _companyService.GetCompanyAsync(id);
        
        if(company == null)
            return NotFound("Company not found.");
        
        var companyModel = new CompanyModel
        {
            Id = company.Id,
            Name = company.Name,
            Description = company.Description,
            Logo = company.Logo
        };
        return View(companyModel);
    }
}