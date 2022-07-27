using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using waste_management_parser.Data.Services;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        private readonly IOrganizationsService _service;

        public OrganizationsController(IOrganizationsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var organizations = await _service.GetOrganizationsByUserIdAndRoleAsync(userId, userRole);

            return View(organizations);
        }

        public async Task<IActionResult> Details(string id)
        {
            var organization = await _service.GetOrganizationByGuidAsync(id);
            return View(organization);
        }
    }
}
