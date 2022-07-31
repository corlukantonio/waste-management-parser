using Microsoft.EntityFrameworkCore;
using System.Text;
using waste_management_parser.Data.Base;
using waste_management_parser.Models;

namespace waste_management_parser.Data.Services
{
    public class ObjectsService : EntityBaseRepository<WmObject>, IObjectsService
    {
        private readonly AppDbContext _context;

        public ObjectsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<WmObject> GetObjectByGuidAsync(string id)
        {
            var wmObject = _context.WmObjects.Include(o => o.WmRecords).FirstOrDefault(o => o.Guid == Encoding.UTF8.GetBytes(id));

            return wmObject;
        }

        public Task<List<WmObject>> GetObjectsByUserIdAndRoleAsync(string userId, string userRole)
        {
            return null;
        }
    }
}
