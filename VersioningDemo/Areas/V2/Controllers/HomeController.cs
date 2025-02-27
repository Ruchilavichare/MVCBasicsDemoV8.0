using Microsoft.AspNetCore.Mvc;

namespace VersioningDemo.Areas.V2.Controllers
{
    [Area("V2")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
