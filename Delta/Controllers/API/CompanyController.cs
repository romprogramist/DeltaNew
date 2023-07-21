using Delta.Models;
using Delta.Services.CompanyService;
using Microsoft.AspNetCore.Mvc;
namespace Delta.Controllers.API;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendCompany(CompanyModel сompany)
    {
        await _companyService.SaveNewCompanyAsync(сompany);
        return Ok();
    }
    
    [HttpGet]
    [Route("approved")]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await _companyService.GetApprovedCompaniesAsync());
    }
    
    [HttpDelete("id")]
    public async Task<ActionResult<List<CompanyModel>>> DeleteCompany(int id)
    {
        var result = await _companyService.DeleteCompany(id);
        if (result is null)
            return NotFound("Hero not found.");

        return Ok(result);
    }
}