using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Controllers
{
    public class PassengersController : Controller
    {
        private readonly SkyTravelDbContext _db;
        public PassengersController(SkyTravelDbContext db) => _db = db;

        public async Task<IActionResult> Index()
            => View(await _db.Passengers.AsNoTracking().OrderBy(p => p.FullName).ToListAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Passenger model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                if (await _db.Passengers.AnyAsync(p => p.Document == model.Document))
                { ModelState.AddModelError("Document", "Documento ya existe."); return View(model); }
                _db.Add(model);
                await _db.SaveChangesAsync();
                TempData["ok"] = "Pasajero registrado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            { TempData["err"] = ex.Message; return View(model); }
        }

        public async Task<IActionResult> Edit(int id)
        { var p = await _db.Passengers.FindAsync(id); return p is null ? NotFound() : View(p); }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Passenger model)
        {
            if (id != model.Id) return BadRequest();
            try
            {
                if (!ModelState.IsValid) return View(model);
                _db.Update(model);
                await _db.SaveChangesAsync();
                TempData["ok"] = "Pasajero actualizado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            { TempData["err"] = ex.Message; return View(model); }
        }
    }
}
