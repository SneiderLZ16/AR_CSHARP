using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Models;
using SkyTravel.Web.Services;

namespace SkyTravel.Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly SkyTravelDbContext _db;
        private readonly IReservationService _svc;

        public ReservationsController(SkyTravelDbContext db, IReservationService svc)
        { _db = db; _svc = svc; }

        public async Task<IActionResult> Index()
        {
            var list = await _db.Reservations
                .Include(r => r.Flight)
                .Include(r => r.Passenger)
                .OrderByDescending(r => r.CreatedUtc)
                .ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Flights = await _db.Flights.Where(f => f.Status == FlightStatus.Programado)
                                               .OrderBy(f => f.DepartureUtc).ToListAsync();
            ViewBag.Passengers = await _db.Passengers.OrderBy(p => p.FullName).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int flightId, int passengerId)
        {
            try
            {
                var res = await _svc.CreateAsync(flightId, passengerId);
                TempData["ok"] = $"Reserva creada ({res.ReservationCode})";
                return RedirectToAction(nameof(Details), new { id = res.Id });
            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;
                return await Create();
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var r = await _db.Reservations.Include(r => r.Flight).Include(r => r.Passenger)
                                           .FirstOrDefaultAsync(r => r.Id == id);
            return r is null ? NotFound() : View(r);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int id)
        {
            try { await _svc.CancelAsync(id); TempData["ok"] = "Reserva cancelada"; }
            catch (Exception ex) { TempData["err"] = ex.Message; }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            try { await _svc.CompleteAsync(id); TempData["ok"] = "Reserva completada"; }
            catch (Exception ex) { TempData["err"] = ex.Message; }
            return RedirectToAction(nameof(Index));
        }
    }
}
