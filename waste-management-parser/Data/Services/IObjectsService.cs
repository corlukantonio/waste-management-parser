using waste_management_parser.Data.Base;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public interface IObjectsService : IEntityBaseRepository<WmObject>
    {
        Task<List<WmObject>> GetObjectsByUserIdAndRoleAsync(string userId, string userRole);

        Task<WmObject> GetObjectByGuidAsync(string id);
    }
}
