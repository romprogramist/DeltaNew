using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.Aboutus;

public interface IAboutusService
{
    Task<bool> AddAboutusAsync(AboutusDto aboutus);
    Task<List<AboutusDto>> GetAboutusAsync();
    Task<List<AboutusModel>> GetAllAboutusAsync();
    Task<AboutusDto?> UpdateAboutusAsync(AboutusDto aboutusDto);
    Task<AboutusDto?> GetAboutusAsync(int id);
    Task<bool> DeleteAboutusAsync(int id);
}