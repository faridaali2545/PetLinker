using Microsoft.AspNetCore.Mvc;
using PetLinker.Data;
using PetLinker.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PetLinker.Controllers
{
    public class ClinicReservationController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ClinicReservationController(ApplicationDBContext context)
        {
            _context = context;
        }

        public IActionResult ReserveClinic()
        {
            return View();
        }

        public IActionResult Index()
        {

            var reservations = _context.Reservations.ToList();
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation(string name, string phone, string date)
        {
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(phone) && date != default)
            {
                var newReservation = new Reservation
                {
                    Name = name,
                    Phone = phone,
                    Date = date
                };

                _context.Reservations.Add(newReservation);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Reservation added successfully!" });
            }

            return Json(new { success = false, message = "All fields are required!" });
        }


        [HttpPost]
        public async Task<IActionResult> EditReservation(int id, string name, string phone, string date)
        {
            var reservation = await _context.Reservations.FindAsync(id);

            if (reservation != null && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(phone) && date != default)
            {
                reservation.Name = name;
                reservation.Phone = phone;
                reservation.Date = date;

                _context.Reservations.Update(reservation);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Reservation updated successfully!" });
            }

            return Json(new { success = false, message = "Invalid data or reservation not found!" });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Reservation deleted successfully!" });
            }

            return Json(new { success = false, message = "Reservation not found!" });
        }
    }
}