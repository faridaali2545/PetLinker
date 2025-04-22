using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetLinker.Models;
using System.Linq;
using System.Collections.Generic;
using PetLinker.Data;

namespace PetLinker.Controllers
{
    public class MarketPlaceController : Controller
    {
        private readonly ApplicationDBContext _context;

        public MarketPlaceController(ApplicationDBContext context)
        {
            _context = context;
        }

        public ActionResult MarketPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RetrieveData(string location)
        {
            if (string.IsNullOrEmpty(location))
            {
                TempData["Error"] = "Please select a valid location.";
                return RedirectToAction("MarketPlace");
            }

            var dbMarketplaces = _context.MarketPlaces
                .Where(m => m.Location.ToLower() == location.ToLower())
                .ToList();

            if (!dbMarketplaces.Any())
            {
                TempData["Error"] = "No marketplaces found for this location.";
                return RedirectToAction("MarketPlace");
            }

            ViewBag.Location = location;
            ViewBag.Marketplaces = dbMarketplaces;

            return View("MarketPlace");
        }
    }
}