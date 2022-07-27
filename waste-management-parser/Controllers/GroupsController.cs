using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using waste_management_parser.Data.Services;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        private readonly IGroupsService _service;

        public GroupsController(IGroupsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var organization = await _service.GetGroupByGuidAsync(id);
            return View(organization);
        }
    }
}
