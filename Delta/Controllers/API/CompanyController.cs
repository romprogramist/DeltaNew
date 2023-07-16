using Delta.Models;
using Delta.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
namespace Delta.Controllers.API;


[ApiController]
[Route("api/company")]

public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }
    
    
    [HttpGet]
    [Route("approved")]
    
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await _companyService.GetApprovedCompaniesAsync());
    }
}