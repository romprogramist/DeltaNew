using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.ContactService;

public interface IContactService
{
    Task<ContactDto?> GetContactAsync(int id);
    Task<bool> AddContactAsync(ContactDto contact);
    Task<string> SaveContactImageAsync(IFormFile requestFile);
    Task<List<ContactModel>> GetAllContactAsync();
    Task<ContactDto?> UpdateContactAsync(ContactDto contactDto);
}