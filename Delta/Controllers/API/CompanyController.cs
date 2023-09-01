using Delta.Models;
using Delta.Models.Dtos;
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
    public async Task<IActionResult> GetСompanies()
    {
        var сompanies = await _companyService.GetCompaniesAsync();
        return Ok(сompanies.Select(p => new CompanyModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Logo = p.Logo
        }).OrderBy(p => p.Id));
    }
    
    [HttpPost]
    [Route("add")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCompany([FromForm] CompanyModel сompany)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            if (requestFiles[0].Length > 1024 * 1024)
            {
                return BadRequest("File size is too large.");
            }
            сompany.Logo = await _companyService.SaveCompanyImageAsync(requestFiles[0]);
        }
        
        var сompanyDto = new CompanyDto
        {
            Name = сompany.Name,
            Description = сompany.Description,
            Logo = сompany.Logo
        };  
        
        var saved = await _companyService.AddCompanyAsync(сompanyDto);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    [HttpPost]
    [Route("update")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateСompany([FromForm] CompanyModel сompany)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            if (requestFiles[0].Length > 1024 * 1024)
            {
                return BadRequest("File size is too large.");
            }
            сompany.ImageUrl = await _companyService.SaveCompanyImageAsync(requestFiles[0]);
        }
        
        else
        {
            сompany.ImageUrl = string.Empty;
        }
        
        
        var companyDto = new CompanyDto
        {
            Id = сompany.Id,
            Name = сompany.Name,
            Description = сompany.Description,
            Logo = сompany.ImageUrl
        };
        
        var savedCompany = await _companyService.UpdateCompanyAsync(companyDto);
        if(savedCompany == null)
            return BadRequest();
        
        var сompanyModel = new CompanyModel
        {
            Id = savedCompany.Id,
            Name = savedCompany.Name,
            Description = savedCompany.Description,
            ImageUrl = savedCompany.Logo
        };
        
        return Ok(сompanyModel);
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var deleted = await _companyService.DeleteCompanyAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
}