using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class GroupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
