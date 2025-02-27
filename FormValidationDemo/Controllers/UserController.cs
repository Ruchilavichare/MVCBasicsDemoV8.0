using Microsoft.AspNetCore.Mvc;
using FormValidationDemo.Models;

namespace FormValidationDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Save user to database or perform other actions
                return RedirectToAction("Success");
            }
            return View(user);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
