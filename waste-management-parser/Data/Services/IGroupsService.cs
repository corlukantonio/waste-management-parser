using waste_management_parser.Data.Base;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public interface IGroupsService : IEntityBaseRepository<WmGroup>
    {
        Task<List<WmGroup>> GetGroupsByUserIdAndRoleAsync(string userId, string userRole);

        Task<WmGroup> GetGroupByGuidAsync(string id);
    }
}
