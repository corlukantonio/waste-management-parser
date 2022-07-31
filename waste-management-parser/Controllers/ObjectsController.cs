using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using waste_management_parser.Data.Services;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class ObjectsController : Controller
    {
        private readonly IObjectsService _service;

        public ObjectsController(IObjectsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            var objects = await _service.GetObjectByGuidAsync(id);
            return View(objects);
        }
    }
}
