using Delta.Services.PhotoAddition;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;


[Route("api/companiesImg")]
[ApiController]
public class FileManagerController : ControllerBase
{
    private readonly IPhotoAddition _iManageImage;
    public FileManagerController(IPhotoAddition iManageImage)
    {
        _iManageImage = iManageImage;
    }

    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> UploadFile(IFormFile iFormFile)
    {
        var result = await _iManageImage.UploadFile(iFormFile);
        return Ok(result);
    }

    // [HttpGet]
    // [Route("downloadfile")]
    // public async Task<IActionResult> DownloadFile(string FileName)
    // {
    //     var result = await _iManageImage.DownloadFile(FileName);
    //     return File(result.Item1, result.Item2, result.Item2);
    // }
}