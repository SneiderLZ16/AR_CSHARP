using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Controllers
{
    public class FlightsController : Controller
    {
        private readonly SkyTravelDbContext _db;
        public FlightsController(SkyTravelDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var flights = await _db.Flights.AsNoTracking().OrderBy(f => f.DepartureUtc).ToListAsync();
            return View(flights);
        }

        public IActionResult Create() => View(new Flight { DepartureUtc = DateTime.UtcNow.AddDays(1), ArrivalUtc = DateTime.UtcNow.AddDays(1).AddHours(1) });

        [HttpPost]
        public async Task<IActionResult> Create(Flight model)
        {
            try
            {
                if (model.ArrivalUtc <= model.DepartureUtc)
                    ModelState.AddModelError("ArrivalUtc", "La llegada debe ser posterior a la salida.");

                if (!ModelState.IsValid) return View(model);

                bool duplicate = await _db.Flights.AnyAsync(f => f.Code == model.Code);
                if (duplicate) { ModelState.AddModelError("Code", "Código de vuelo ya existe."); return View(model); }

                _db.Flights.Add(model);
                await _db.SaveChangesAsync();
                TempData["ok"] = "Vuelo registrado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["err"] = $"Error creando vuelo: {ex.Message}";
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var f = await _db.Flights.FindAsync(id);
            return f is null ? NotFound() : View(f);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Flight model)
        {
            if (id != model.Id) return BadRequest();
            try
            {
                if (!ModelState.IsValid) return View(model);
                _db.Update(model);
                await _db.SaveChangesAsync();
                TempData["ok"] = "Vuelo actualizado";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                TempData["err"] = $"Error de base de datos: {ex.Message}";
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, FlightStatus status)
        {
            var f = await _db.Flights.FindAsync(id);
            if (f is null) return NotFound();
            f.Status = status;
            await _db.SaveChangesAsync();
            TempData["ok"] = "Estado actualizado";
            return RedirectToAction(nameof(Index));
        }
    }
}
