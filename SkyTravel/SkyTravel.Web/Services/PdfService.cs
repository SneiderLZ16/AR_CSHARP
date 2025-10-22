using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SkyTravel.Web.Models;

namespace SkyTravel.Web.Services
{
    public class PdfService : IPdfService
    {
        public byte[] BuildTicketPdf(Reservation r)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Header().Text("SKYTRAVEL - TICKET DE VUELO").SemiBold().FontSize(18);
                    page.Content().Column(col =>
                    {
                        col.Spacing(6);
                        col.Item().Text($"Pasajero: {r.Passenger.FullName}");
                        col.Item().Text($"Documento: {r.Passenger.Document}");
                        col.Item().Text($"Vuelo: {r.Flight.Code}");
                        col.Item().Text($"Origen: {r.Flight.Origin}");
                        col.Item().Text($"Destino: {r.Flight.Destination}");
                        col.Item().Text($"Fecha de salida: {r.Flight.DepartureUtc:u}");
                        col.Item().Text($"Asiento: {r.SeatCode}");
                        col.Item().Text($"Código de reserva: {r.ReservationCode}");
                        col.Item().Text($"Estado del ticket: Generado");
                    });
                    page.Footer().AlignCenter().Text($"Generado: {DateTime.UtcNow:u}");
                });
            }).GeneratePdf();
        }
    }
}
