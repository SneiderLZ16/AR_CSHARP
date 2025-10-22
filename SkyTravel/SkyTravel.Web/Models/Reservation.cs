using System.ComponentModel.DataAnnotations;

namespace SkyTravel.Web.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; } = default!;
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; } = default!;

        [Required, StringLength(5)] public string SeatCode { get; set; } = default!; // ej. 12B

        [Required] public ReservationStatus Status { get; set; } = ReservationStatus.Activa;

        [Required, StringLength(12)] public string ReservationCode { get; set; } = default!; // ej. 8F2A9C

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
