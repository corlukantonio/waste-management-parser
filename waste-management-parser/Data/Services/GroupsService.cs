using Microsoft.EntityFrameworkCore;
using System.Text;
using waste_management_parser.Data.Base;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public class GroupsService : EntityBaseRepository<WmGroup>, IGroupsService
    {
        private readonly AppDbContext _context;

        public GroupsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<WmGroup>> GetGroupsByUserIdAndRoleAsync(string userId, string userRole)
        {
            return null;
        }

        public async Task<WmGroup> GetGroupByGuidAsync(string id)
        {
            var group = _context.WmGroups.Include(g => g.WmObjects).FirstOrDefault(o => o.Guid == Encoding.UTF8.GetBytes(id));

            return group;
        }
    }
}
