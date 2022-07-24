using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace waste_management_parser.Controllers
{
    [Authorize]
    public class OrganizationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
