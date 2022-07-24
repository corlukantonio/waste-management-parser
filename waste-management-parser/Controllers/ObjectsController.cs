using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class ObjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
