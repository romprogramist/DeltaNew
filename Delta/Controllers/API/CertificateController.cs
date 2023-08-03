using Delta.Models;
using Delta.Services.CertificatesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;



[ApiController]
[Route("api/certificate")]

public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetCertificates()
    {
        var certificates = await _certificateService.GetCertificatesAsync();
        return Ok(certificates);
    }
    
    
    [HttpPost]
    [Route("add")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddCertificate(CertificateModel certificate)
    {
        var saved = await _certificateService.AddCertificateAsync(certificate);
        if(!saved)
            return BadRequest();
        return Ok();
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteCertificate(int id)
    {
        var deleted = await _certificateService.DeleteCertificateAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
}