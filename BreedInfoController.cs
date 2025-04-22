using Microsoft.AspNetCore.Mvc;
using PetLinker.Data;
using PetLinker.Models;

namespace PetLinker.Controllers
{
    public class BreedInfoController : Controller
    {
        private readonly ApplicationDBContext _context;

        public BreedInfoController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult BreedInfo()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetBreedDetails(string breed)
        {

            var BreedInfo = _context.BreedInfos.FirstOrDefault(b => b.Breed == breed);

            if (BreedInfo != null)
            {

                return Json(new
                {
                    ImageUrl = "/images/Breeds/" + BreedInfo.ImageUrl,
                    Description = BreedInfo.Description
                });
            }

            return Json(null);
        }


        [HttpPost]
        public JsonResult GetBreeds(string petType)
        {

            var breeds = _context.BreedInfos
                                 .Where(b => b.PetType == petType)
                                 .Select(b => new { b.Breed })
                                 .ToList();

            return Json(breeds);
        }
    }
}