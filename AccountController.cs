using Microsoft.AspNetCore.Mvc;
using PetLinker.Models;
using PetLinker.Data;
using System.Linq;

namespace PetLinker.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AccountController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "Username and password are required.");
                return View();
            }

            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null || user.Password != password)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View();
            }
            HttpContext.Session.SetString("Username", user.Username);

            return RedirectToAction("Profile", "Profile");
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string email, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("", "All fields are required.");
                return View();
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError("", "Username already exists.");
                return View();
            }

            var newUser = new UserProfile
            {
                Username = username,
                Email = email,
                Password = password 
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            return RedirectToAction("Profile","Profile");
        }
    }
}
