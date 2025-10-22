using SkyTravel.Web.Models;

namespace SkyTravel.Web.Services
{
    public interface ISeatAllocator
    {
        string AllocateSeat(Flight flight, IEnumerable<string> takenSeatCodes);
    }

    public class SeatAllocator : ISeatAllocator
    {
        private readonly Dictionary<int, Queue<string>> _seatPools = new();

        public string AllocateSeat(Flight flight, IEnumerable<string> takenSeatCodes)
        {
            if (!_seatPools.TryGetValue(flight.Id, out var pool))
            {
                var all = new List<string>();
                for (int row = 1; row <= Math.Min(99, Math.Max(1, flight.TotalSeats / 6 + 1)); row++)
                    foreach (char col in new[] { 'A','B','C','D','E','F' })
                        all.Add($"{row}{col}");

                var set = new HashSet<string>(takenSeatCodes);
                var free = all.Where(s => !set.Contains(s)).Take(flight.TotalSeats).ToList();
                pool = new Queue<string>(free);
                _seatPools[flight.Id] = pool;
            }
            if (pool.Count == 0) throw new InvalidOperationException("No hay asientos disponibles.");
            return pool.Dequeue();
        }
    }
}
