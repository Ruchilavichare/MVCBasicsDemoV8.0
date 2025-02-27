using Microsoft.AspNetCore.Mvc;
using MVCDIExample.Models;
using MVCDIExample.Services;
using System.Diagnostics;

namespace MVCDIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGreetingService _greetingService;

        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        public IActionResult Index()
        {
            ViewData["Greeting"] = _greetingService.GetGreeting("User");
            return View();
        }
    }
}
