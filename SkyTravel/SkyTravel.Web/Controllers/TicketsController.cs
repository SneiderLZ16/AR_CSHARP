using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Services;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly SkyTravelDbContext _db;
        private readonly IPdfService _pdf;

        public TicketsController(SkyTravelDbContext db, IPdfService pdf)
        { _db = db; _pdf = pdf; }

        [HttpPost]
        public async Task<IActionResult> Generate(int reservationId)
        {
            var r = await _db.Reservations
                .Include(x => x.Flight).Include(x => x.Passenger)
                .FirstOrDefaultAsync(x => x.Id == reservationId);
            if (r is null) return NotFound();

            try
            {
                var bytes = _pdf.BuildTicketPdf(r);
                var fileName = $"ticket_{r.ReservationCode}.pdf";

                _db.TicketHistories.Add(new TicketHistory
                {
                    ReservationId = r.Id,
                    Status = TicketStatus.Generado,
                    Message = "OK",
                    FileName = fileName
                });
                await _db.SaveChangesAsync();

                return File(bytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                _db.TicketHistories.Add(new TicketHistory
                {
                    ReservationId = r.Id,
                    Status = TicketStatus.Error,
                    Message = ex.Message
                });
                await _db.SaveChangesAsync();
                TempData["err"] = "Error generando PDF";
                return RedirectToAction("Details", "Reservations", new { id = r.Id });
            }
        }
    }
}
