using Delta.Data;
using Delta.Models;
using Delta.Models.Dtos;

namespace Delta.Services.ReagentService;

public interface IReagentService
{
    Task<bool> AddReagentAsync(ReagentDto reagent);
    Task<List<ReagentDto>> GetReagentsAsync();
    Task<bool> DeleteReagentAsync(int id);
    Task<string> SaveReagentImageAsync(IFormFile requestFile);
    Task<ReagentDto?> GetReagentAsync(int id);
}

