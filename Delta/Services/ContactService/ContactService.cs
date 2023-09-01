using Delta.Data;
using Delta.Helpers;
using Delta.Models;
using Delta.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Delta.Services.ContactService;

public class ContactService : IContactService
{
    private readonly DeltaDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public ContactService(DeltaDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    
    
    public async Task<List<ContactModel>> GetAllContactAsync()
    {
        var contact = await _context.Contacts.ToListAsync();
    
        var contactModel = contact.Select(cont => new ContactModel
        {
            Id = cont.Id,
            HeaderNumber = cont.HeaderNumber,
            NumberOne = cont.NumberOne,
            NumberTwo = cont.NumberTwo,
            HeaderTimetable = cont.HeaderTimetable,
            Monday = cont.Monday,
            Friday = cont.Friday,
            Saturday = cont.Saturday,
            ImgBg = cont.ImgBg,
            Address = cont.Address
        }).ToList();
    
        return contactModel;
    }

    public async Task<ContactDto?> UpdateContactAsync(ContactDto contactDto)
    {
        var contactToUpdate = await _context.Contacts.FindAsync(contactDto.Id);
        if (contactToUpdate is null)
            return null;
        contactToUpdate.HeaderNumber = contactDto.HeaderNumber;
        contactToUpdate.NumberOne = contactDto.NumberOne;
        contactToUpdate.NumberTwo = contactDto.NumberTwo;
        contactToUpdate.HeaderTimetable = contactDto.HeaderTimetable;
        contactToUpdate.Monday = contactDto.Monday;
        contactToUpdate.Friday = contactDto.Friday;
        contactToUpdate.Saturday = contactDto.Saturday;
        // contactToUpdate.ImgBg = contactDto.ImgBg;
        contactToUpdate.Address = contactDto.Address;
        
        
        if (!string.IsNullOrEmpty(contactDto.ImgBg))
        {
            contactToUpdate.ImgBg = contactDto.ImgBg;
        }
        
        
        _context.Contacts.Update(contactToUpdate);
        var savedCount = await _context.SaveChangesAsync();
        if (savedCount <= 0)
            return null;

        contactDto = new ContactDto
        {
            Id = contactToUpdate.Id
        };
        
        return contactDto;
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        var contact = await _context.Contacts.FindAsync(id);
        if (contact is null)
            return false;
    
        _context.Contacts.Remove(contact);
        var saveCount = await _context.SaveChangesAsync();
    
        return saveCount > 0;
    }


    public async Task<ContactDto?> GetContactAsync(int id)
    {
        return await _context.Contacts
            .Where(p => p.Id == id)
            .Select(p => new ContactDto
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
                Address = p.Address
            }).FirstOrDefaultAsync();
    }

    public async Task<bool> AddContactAsync(ContactDto contact)
    {
        _context.Contacts.Add(new Contacts
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
        });
    
        var savedCount = await _context.SaveChangesAsync();
    
        return savedCount > 0;
    }

    public async Task<string> SaveContactImageAsync(IFormFile file)
    {
        var uniqueFileName = FileHelper.GetUniqueFileName(file.FileName);
        var uploadDirectory = Path.Combine(_environment.WebRootPath, "images", "companies");
        var filePath = Path.Combine(uploadDirectory, uniqueFileName);
        Directory.CreateDirectory(Path.GetDirectoryName(filePath) ?? throw new InvalidOperationException());
        await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
        return uniqueFileName;
    }
}