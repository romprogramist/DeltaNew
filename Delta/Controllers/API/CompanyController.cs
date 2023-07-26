using Delta.Models;
using Delta.Services.CompanyService;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _companyService.GetCompaniesAsync();
        return Ok(companies);
    }

    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCompany(CompanyModel сompany)
    {
        var saved = await _companyService.AddCompanyAsync(сompany);
        if(!saved)
            return BadRequest();
        return Ok();
    }

    [HttpDelete]
    [Route("delete/{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var deleted = await _companyService.DeleteCompanyAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
}