using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetLinker.Data; 
using PetLinker.Models;
using System.Linq;
using System.Collections.Generic;

namespace PetLinker.Controllers
{
    public class PetActivityController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public PetActivityController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Activity()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult RetrieveData(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                TempData["Error"] = "Please select a valid location.";
                return RedirectToAction("Activity");
            }

            var petActivities = _dbContext.PetActivities
                                          .Where(p => p.Location == location)
                                          .ToList();

            ViewBag.PetActivities = petActivities;
            ViewBag.Location = location;

            return View("Activity");
        }
    }

}