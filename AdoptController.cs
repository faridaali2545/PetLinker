using Microsoft.AspNetCore.Mvc;
using PetLinker.Models;
using PetLinker.Data;
using System.Linq;
using System.Collections.Generic;

public class AdoptController : Controller
{
    private readonly ApplicationDBContext _context;

    public AdoptController(ApplicationDBContext context)
    {
        _context = context;
    }

    public IActionResult AdoptPet(int page = 1, int pageSize = 10, string search = "", string type = "")
    {
        if (page < 1) page = 1;
        if (pageSize < 1 || pageSize > 50) pageSize = 10;

        var query = _context.Pets.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => p.Type.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(type))
        {
            query = query.Where(p => p.Type == type);
        }

        var totalItems = query.Count();
        var pets = query
            .Where(p => p.Status == "Free")
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewData["CurrentPage"] = page;
        ViewData["TotalPages"] = (int)Math.Ceiling((double)totalItems / pageSize);

        return View(pets);
    }

    public IActionResult ViewProfile(int id)
    {
        var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

        if (pet == null)
        {
            return View("Error", new { Message = "Pet not found." });
        }

        return View(pet);
    }

    public IActionResult AdoptionQuiz(int petId)
    {
        var questions = new List<string>
        {
            "How much time do you have to spend with the pet daily?",
            "What is your level of experience with pets?",
            "Are you financially prepared to take care of a pet?",
            "Do you have training experience with pets?",
            "Do you have a plan for your pet's future if you can no longer care for them?"
        };

        var options = new List<List<string>>
        {
            new List<string> { "1-2 hours", "3-4 hours", "5+ hours", "None" },
            new List<string> { "None", "Some experience", "Moderate experience", "Expert" },
            new List<string> { "Yes", "No", "Not sure", "Already adopted from a shelter" },
            new List<string> { "None", "Basic training", "Advanced training", "Expert trainer" },
            new List<string> { "No", "Yes, I have a plan", "I am considering one", "Not sure" }
        };

        ViewData["Questions"] = questions;
        ViewData["Options"] = options;
        ViewData["PetId"] = petId;

        return View();
    }

    [HttpPost]
    public IActionResult SubmitAdoptionQuiz(int petId, List<string> answers)
    {
        if (answers == null || answers.Count < 5)
        {
            ViewData["Error"] = "Please answer all questions.";
            return View("AdoptionQuiz", new { petId = petId });
        }

        int score = 0;
        var answerScores = new Dictionary<string, int>
        {
            { "None", 0 },
            { "Some experience", 1 },
            { "Moderate experience", 2 },
            { "Expert", 3 },
            { "Yes", 3 },
            { "No", 0 },
            { "Already adopted from a shelter", 1 },
            { "Basic training", 1 },
            { "Advanced training", 2 },
            { "Expert trainer", 3 },
            { "Yes, I have a plan", 3 },
            { "I am considering one", 2 },
            { "Not sure (question 1)", 1 },
            { "Not sure (question 2)", 1 },
            { "Not sure (question 3)", 1 },
            { "Not sure (question 4)", 1 },
            { "Not sure (question 5)", 1 }
        };

        foreach (var answer in answers)
        {
            if (answerScores.ContainsKey(answer))
            {
                score += answerScores[answer];
            }
        }

        var user = _context.Users.FirstOrDefault(u => u.Username == User.Identity.Name);

        if (user == null)
        {
            ViewData["Error"] = "User not found.";
            return View("AdoptionQuiz", new { petId = petId });
        }

        if (score >= 3)
        {
            var pet = _context.Pets.FirstOrDefault(p => p.Id == petId);

            if (pet != null && pet.Status == "Free")
            {
                user.Status = "Adopter";
                pet.Status = "Adopted";
                pet.UserProfileUsername = user.Username;
                _context.SaveChanges();

                ViewData["Message"] = "You passed the quiz! You can now adopt this pet.";
            }
            else
            {
                ViewData["Message"] = "This pet is no longer available for adoption.";
            }
        }
        else
        {
            ViewData["Message"] = "Unfortunately, you did not pass the quiz.";
        }

        ViewData["UserAnswers"] = answers;

        return View("AdoptionQuiz", new { petId = petId });
    }

    public IActionResult Adopt(int id)
    {
        var pet = _context.Pets.FirstOrDefault(p => p.Id == id);

        if (pet == null)
        {
            return View("Error", new { Message = "Pet not found." });
        }

        if (pet.Status != "Free")
        {
            return View("Error", new { Message = "Pet has already been adopted." });
        }

        var username = User.Identity.Name;
        var user = _context.Users.FirstOrDefault(u => u.Username == username);

        if (user == null)
        {
            return View("Error", new { Message = "User not found." });
        }

        pet.Status = "Adopted";
        pet.UserProfileUsername = user.Username;

        _context.SaveChanges();

        return RedirectToAction("AdoptPet");
    }
}
