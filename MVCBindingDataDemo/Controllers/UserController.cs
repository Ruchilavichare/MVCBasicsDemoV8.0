using Microsoft.AspNetCore.Mvc;
using MVCBindingDataDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCBindingDataDemo.Controllers
{
    public class UserController : Controller
    {
        private static List<User> _users = new List<User>();

        // GET: User/Create (Form Binding)
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create (Form Binding)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = _users.Count + 1; // Assign a unique ID
                _users.Add(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Index (Query String Binding)
        public IActionResult Index([FromQuery] string search)
        {
            var users = _users.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(u => u.Name.Contains(search) || u.Email.Contains(search));
            }

            return View(users.ToList());
        }

        // POST: User/CreateUser (JSON Binding)
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.UserId = _users.Count + 1; // Assign a unique ID
            _users.Add(user);

            return Ok(new { UserId = user.UserId });
        }

        // GET: User/GetUser (Query String Binding)
        public IActionResult GetUser([FromQuery] int userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
