using Microsoft.AspNetCore.Mvc;

namespace waste_management_parser.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
