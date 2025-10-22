using System.ComponentModel.DataAnnotations;

namespace SkyTravel.Web.Models
{
    public class TicketHistory
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; } = default!;

        [Required] public TicketStatus Status { get; set; }
        [StringLength(500)] public string? Message { get; set; }
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
        [StringLength(80)] public string? FileName { get; set; }
    }
}
