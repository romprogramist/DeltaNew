using Delta.Models;
using Delta.Models.Dtos;
using Delta.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Controllers.API;

[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }
    
    
    [HttpGet]
    [Route("get")]
    public async Task<IActionResult> GetContacts()
    {
        var contacts = await _contactService.GetAllContactAsync();
        return Ok(contacts.Select(p => new ContactModel
        {
            Id = p.Id,
            HeaderNumber = p.HeaderNumber,
            NumberOne = p.NumberOne,
            NumberTwo = p.NumberTwo,
            HeaderTimetable = p.HeaderTimetable,
            Monday = p.Monday,
            Friday = p.Friday,
            Saturday = p.Saturday,
            ImgBg = p.ImgBg,
            Address = p.Address,
        }).OrderBy(p => p.Id));
    }
    
    [HttpPost]
    [Route("add")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddContact([FromForm] ContactModel contact)
    {
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            // if (requestFiles[0].Length > 1024 * 1024)
            // {
            //     return BadRequest("File size is too large.");
            // }
            contact.ImgBg = await _contactService.SaveContactImageAsync(requestFiles[0]);
        }
        
        // else
        // {
        //     contact.ImgBg = string.Empty;
        // }
        
        var contactDto = new ContactDto
        {
            HeaderNumber = contact.HeaderNumber,
            NumberOne = contact.NumberOne,
            NumberTwo = contact.NumberTwo,
            HeaderTimetable = contact.HeaderTimetable,
            Monday = contact.Monday,
            Friday = contact.Friday,
            Saturday = contact.Saturday,
            ImgBg = contact.ImgBg,
            Address = contact.Address
        };  
        
        var saved = await _contactService.AddContactAsync(contactDto);
        if(!saved)
            return BadRequest("No NO NO NO NO NO NO NO NO");
        return Ok();
    }
    
    
    
    [HttpPost]
    [Route("update")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateContact([FromForm] ContactModel contact)
    {
        
        var requestFiles = Request.Form.Files;
        if (requestFiles.Count > 0)
        {
            // if (requestFiles[0].Length > 1024 * 1024)
            // {
            //     return BadRequest("File size is too large.");
            // }
            contact.ImgBg = await _contactService.SaveContactImageAsync(requestFiles[0]);
        }
        
        else
        {
            contact.ImgBg = string.Empty;
        }
        
        var contactDto = new ContactDto
        {
            Id = contact.Id,
            HeaderNumber = contact.HeaderNumber,
            NumberOne = contact.NumberOne,
            NumberTwo = contact.NumberTwo,
            HeaderTimetable = contact.HeaderTimetable,
            Monday = contact.Monday,
            Friday = contact.Friday,
            Saturday = contact.Saturday,
            ImgBg = contact.ImgBg,
            Address = contact.Address
        };
        
        var savedContact = await _contactService.UpdateContactAsync(contactDto);
        if(savedContact == null)
            return BadRequest();
        
        var contactModel = new ContactModel
        {
            Id = savedContact.Id,
            HeaderNumber = savedContact.HeaderNumber,
            NumberOne = savedContact.NumberOne,
            NumberTwo = savedContact.NumberTwo,
            HeaderTimetable = savedContact.HeaderTimetable,
            Monday = savedContact.Monday,
            Friday = savedContact.Friday,
            Saturday = savedContact.Saturday,
            ImgBg = savedContact.ImgBg,
            Address = savedContact.Address
        };
        
        return Ok(contactModel);
    }
    
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    // [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        var deleted = await _contactService.DeleteContactAsync(id);
        if(!deleted)
            return BadRequest();
        return Ok();
    }
    
    
}