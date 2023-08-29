using Delta.Models;
using Delta.Services.ContactService;
using Microsoft.AspNetCore.Mvc;

namespace Delta.Areas.Admin.Controllers;

public class ContactController : BaseAdminController
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
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
        var contact = await _contactService.GetContactAsync(id);
        
        if(contact == null)
            return NotFound("contact not found.");
        
        var contactModel = new ContactModel
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
        return View(contactModel);
    }
    
}