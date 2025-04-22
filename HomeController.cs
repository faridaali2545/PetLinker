using Microsoft.AspNetCore.Mvc;
using PetLinker.Models;
using PetLinker.Data;
using System.Diagnostics;

namespace PetLinker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public HomeController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Feedback(UserProfile model)
        {
            if (ModelState.IsValid)
            {
                var username = HttpContext.Session.GetString("Username");

                if (string.IsNullOrEmpty(username))
                {
                    ViewBag.ErrorMessage = "You must be logged in to submit feedback.";
                    return View();
                }

                var user = _context.Users.FirstOrDefault(u => u.Username == username);

                if (user == null)
                {
                    ViewBag.ErrorMessage = "User not found.";
                    return View();
                }

                user.Feedback = model.Feedback;

                _context.SaveChanges();

                return RedirectToAction("Profile", "Profile");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

