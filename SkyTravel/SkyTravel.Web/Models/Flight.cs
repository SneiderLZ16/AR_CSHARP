using System.ComponentModel.DataAnnotations;

namespace SkyTravel.Web.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string Code { get; set; } = default!; // único

        [Required, StringLength(100)] public string Origin { get; set; } = default!;
        [Required, StringLength(100)] public string Destination { get; set; } = default!;

        [DataType(DataType.DateTime)] public DateTime DepartureUtc { get; set; }
        [DataType(DataType.DateTime)] public DateTime ArrivalUtc { get; set; }

        [Range(1, 600)] public int TotalSeats { get; set; }

        public FlightStatus Status { get; set; } = FlightStatus.Programado;

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public int SeatsAvailable => TotalSeats - Reservations.Count(r => r.Status == ReservationStatus.Activa);
    }
}
