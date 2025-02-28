using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecureMvcApp.Models;

namespace SecureMvcApp.Controllers
{
    [Authorize] // Restrict access to authenticated users
    public class UserProfileController : Controller
    {
        // Display the user profile form
        public IActionResult Edit()
        {
            return View();
        }

        // Handle form submission
        [HttpPost]
        [ValidateAntiForgeryToken] // Protect against CSRF attacks
        public IActionResult Edit(UserProfileModel model)
        {
            if (ModelState.IsValid)
            {
                // Validate file type and size
                var allowedExtensions = new[] { ".jpg", ".png" };
                var extension = Path.GetExtension(model.ProfilePicture.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("ProfilePicture", "Invalid file type. Only JPG and PNG are allowed.");
                    return View(model);
                }

                if (model.ProfilePicture.Length > 5 * 1024 * 1024) // 5 MB
                {
                    ModelState.AddModelError("ProfilePicture", "File size exceeds the limit.");
                    return View(model);
                }

                // Save the file and update the profile
                // Example: Save file to wwwroot/uploads
                var filePath = Path.Combine("wwwroot/uploads", model.ProfilePicture.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePicture.CopyTo(stream);
                }

                // Redirect to a success page
                return RedirectToAction("ProfileUpdated");
            }

            // If the model is invalid, return to the form
            return View(model);
        }

        // Display a success message
        public IActionResult ProfileUpdated()
        {
            return View();
        }
    }
}