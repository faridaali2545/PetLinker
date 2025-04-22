using Microsoft.AspNetCore.Mvc;
using PetLinker.Models;
using PetLinker.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace PetLinker.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProfileController(ApplicationDBContext context)
        {
            _context = context;
        }
        public ActionResult Profile()
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                ViewBag.ErrorMessage = "User not logged in.";
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found.";
                return View();
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitFeedback(string message)
        {
            var username = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                ViewBag.ErrorMessage = "User not logged in.";
                return RedirectToAction("Login", "Account");
            }

            if (string.IsNullOrEmpty(message))
            {
                ViewBag.ErrorMessage = "Please provide a message.";
                return View("Feedback");
            }

            var userProfile = _context.Users.FirstOrDefault(u => u.Username == username);

            if (userProfile != null)
            {
                userProfile.Feedback = message;
                _context.SaveChanges();

                ViewBag.SuccessMessage = "Your feedback has been submitted successfully.";
                return RedirectToAction("Profile");
            }

            ViewBag.ErrorMessage = "User not found.";
            return View("Feedback");
        }

    }
}
