using Delta.Data;
using Delta.Models;

namespace Delta.Services.ReagentService;

public interface IReagentService
{
    Task<bool> AddReagentAsync(ReagentModel reagent);
    Task<IEnumerable<ReagentModel>> GetReagentsAsync();
    Task<bool> DeleteReagentAsync(int id);
}