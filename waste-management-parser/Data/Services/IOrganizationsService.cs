using waste_management_parser.Data.Base;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public interface IOrganizationsService : IEntityBaseRepository<WmOrganization>
    {
        Task<List<WmOrganization>> GetOrganizationsByUserIdAndRoleAsync(string userId, string userRole);
    }
}
