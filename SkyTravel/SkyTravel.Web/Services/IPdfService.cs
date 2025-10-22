using SkyTravel.Web.Models;

namespace SkyTravel.Web.Services
{
    public interface IPdfService
    {
        byte[] BuildTicketPdf(Reservation reservation);
    }
}
