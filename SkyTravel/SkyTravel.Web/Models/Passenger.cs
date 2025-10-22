using System.ComponentModel.DataAnnotations;

namespace SkyTravel.Web.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required, StringLength(150)] public string FullName { get; set; } = default!;
        [Required, StringLength(20)]  public string Document { get; set; } = default!; // único
        [Phone, StringLength(30)]     public string? Phone { get; set; }
        [EmailAddress, StringLength(150)] public string? Email { get; set; }

        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
