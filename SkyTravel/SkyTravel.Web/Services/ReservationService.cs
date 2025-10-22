using Microsoft.EntityFrameworkCore;
using SkyTravel.Web.Data;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Services
{
    public class ReservationService : IReservationService
    {
        private readonly SkyTravelDbContext _db;
        private readonly ISeatAllocator _seats;

        public ReservationService(SkyTravelDbContext db, ISeatAllocator seats)
        { _db = db; _seats = seats; }

        public async Task<Reservation> CreateAsync(int flightId, int passengerId)
        {
            var flight = await _db.Flights.Include(f => f.Reservations)
                                          .FirstOrDefaultAsync(f => f.Id == flightId)
                          ?? throw new ArgumentException("Vuelo no encontrado");
            var passenger = await _db.Passengers.FindAsync(passengerId)
                          ?? throw new ArgumentException("Pasajero no encontrado");

            if (flight.Status is FlightStatus.Cancelado or FlightStatus.Finalizado)
                throw new InvalidOperationException("No se puede reservar en un vuelo cancelado o finalizado.");

            if (flight.DepartureUtc > DateTime.UtcNow.AddDays(30))
                throw new InvalidOperationException("Solo se permite reservar hasta 30 días antes de la salida.");

            if (flight.SeatsAvailable <= 0)
                throw new InvalidOperationException("No hay asientos disponibles.");

            bool alreadyActive = flight.Reservations.Any(r => r.PassengerId == passengerId && r.Status == ReservationStatus.Activa);
            if (alreadyActive)
                throw new InvalidOperationException("El pasajero ya tiene una reserva activa en este vuelo.");

            var taken = flight.Reservations.Where(r => r.Status == ReservationStatus.Activa).Select(r => r.SeatCode);
            var seat = _seats.AllocateSeat(flight, taken);

            string code = GenerateCode(6);

            var reservation = new Reservation
            {
                FlightId = flight.Id,
                PassengerId = passenger.Id,
                SeatCode = seat,
                ReservationCode = code,
                Status = ReservationStatus.Activa
            };

            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
            return reservation;
        }

        public async Task CancelAsync(int reservationId)
        {
            var res = await _db.Reservations.Include(r => r.Flight)
                                            .FirstOrDefaultAsync(r => r.Id == reservationId)
                      ?? throw new ArgumentException("Reserva no encontrada");
            if (res.Status != ReservationStatus.Activa)
                throw new InvalidOperationException("Solo reservas activas se pueden cancelar.");
            res.Status = ReservationStatus.Cancelada;
            await _db.SaveChangesAsync();
        }

        public async Task CompleteAsync(int reservationId)
        {
            var res = await _db.Reservations.Include(r => r.Flight)
                                            .FirstOrDefaultAsync(r => r.Id == reservationId)
                      ?? throw new ArgumentException("Reserva no encontrada");
            if (res.Flight.Status != FlightStatus.Finalizado)
                throw new InvalidOperationException("La reserva solo se completa cuando el vuelo ha finalizado.");
            res.Status = ReservationStatus.Completada;
            await _db.SaveChangesAsync();
        }

        private static string GenerateCode(int len)
        {
            var rnd = Random.Shared;
            const string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            return new string(Enumerable.Range(0, len).Select(_ => alphabet[rnd.Next(alphabet.Length)]).ToArray());
        }
    }
}
