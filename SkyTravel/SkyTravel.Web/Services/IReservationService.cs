using SkyTravel.Web.Models;

namespace SkyTravel.Web.Services
{
    public interface IReservationService
    {
        Task<Reservation> CreateAsync(int flightId, int passengerId);
        Task CancelAsync(int reservationId);
        Task CompleteAsync(int reservationId);
    }
}
