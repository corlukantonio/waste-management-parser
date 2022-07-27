using Microsoft.EntityFrameworkCore;
using waste_management_parser.Data.Base;
using waste_management_parser.Data.Static;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public class OrganizationsService : EntityBaseRepository<WmOrganization>, IOrganizationsService
    {
        private readonly AppDbContext _context;

        public OrganizationsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<WmOrganization>> GetOrganizationsByUserIdAndRoleAsync(string userId, string userRole)
        {
            var organizations = await _context.WmOrganizations.ToListAsync();
            var usersOrganizations = await _context.AspNetUsers_WmOrganizations.Where(n => n.UserId == userId).ToListAsync();

            if (userRole != UserRoles.Admin)
            {
                organizations = organizations.Where(o => o.Users_WmOrganizations != null ? o.Users_WmOrganizations.Any(uo => uo.UserId == userId) : default).ToList();
            }

            return organizations;
        }
    }
}
