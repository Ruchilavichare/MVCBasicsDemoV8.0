using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SecureMvcApp.Controllers
{
    [Authorize(Roles = "Admin")] // Restrict access to users with the "Admin" role
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult ManageUsers()
        {
            return View();
        }
    }
}
