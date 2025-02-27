using Microsoft.AspNetCore.Mvc;

namespace VersioningDemo.Areas.V1.Controllers
{
    [Area("V1")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
