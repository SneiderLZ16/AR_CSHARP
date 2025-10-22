using RiwiMusic.Models;
namespace RiwiMusic.Manage;
public static class ManageTickets
{
    public static void ManageTicketsMenu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Administrar Tickets =====");
            Console.WriteLine("1. Crear");
            Console.WriteLine("2. Editar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar");
            Console.WriteLine("0. Salir");
            
            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("\n=== Crear Ticket ===");
                    CreateTicket();
                    break;
                case 2:
                    Console.WriteLine("\n=== Editar Ticket ===");
                    EditTicket();
                    break;
                case 3:
                    Console.WriteLine("\n=== Eliminar Ticket ===");
                    DeleteTicket();
                    break;
                case 4:
                    Console.WriteLine("\n=== Mostrar Tickets ===");
                    ShowTickets();
                    break;
                case 0:
                    Console.WriteLine("\n== Salir ==");
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        } while (menu);
    }
    private static void CreateTicket()
    {   //Get ClientId, ConcertId, TicketAmount, TicketPriceTotal
        Console.Write("Ingrese Id del Cliente: ");
        int clientId = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese Id del Concierto: ");
        int concertId = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese cantidad de boletos: ");
        int amount = int.Parse(Console.ReadLine()!);

        Console.Write("Ingrese precio total del ticket: ");
        double total = double.Parse(Console.ReadLine()!);

        AddTicket(clientId, concertId, amount, total); //Send data to AddTicket
    }
    private static void AddTicket(int clientId, int concertId, int amount, double total)
    {
        var newTicket = new Ticket()
        {
            TicketId = DataStore.IdCounterT++,
            ClientId = clientId,
            ConcertId = concertId,
            TicketAmount = amount,
            TicketPriceTotal = total
        };
        DataStore.Tickets.Add(newTicket); //Add newTicket to Tickets
        Console.WriteLine("Ticket creado correctamente.");
    }
    private static void EditTicket()
    {
        Console.Write("\nIngrese el ID del ticket a editar: ");
        int idEdit = int.Parse(Console.ReadLine()!);
        
        var ticket = DataStore.Tickets.FirstOrDefault(ticket => ticket.TicketId == idEdit);
        if (ticket != null)
        {   //Get new data to Update Ticket
            Console.Write("Nuevo Id del Cliente: ");
            ticket.ClientId = int.Parse(Console.ReadLine()!);

            Console.Write("Nuevo Id del Concierto: ");
            ticket.ConcertId = int.Parse(Console.ReadLine()!);

            Console.Write("Nueva cantidad: ");
            ticket.TicketAmount = int.Parse(Console.ReadLine()!);

            Console.Write("Nuevo precio total: ");
            ticket.TicketPriceTotal = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Ticket actualizado.");
        }
        else
        {
            Console.WriteLine("No se encontró el ticket.");
        }
    }
    private static void DeleteTicket()
    {
        Console.Write("\nIngrese el ID del Ticket a eliminar: ");
        int idClear = Convert.ToInt32(Console.ReadLine());
        
        var ticket = DataStore.Tickets.FirstOrDefault(ticket => ticket.TicketId == idClear);
        if (ticket != null)
        {
            DataStore.Tickets.Remove(ticket);
            Console.WriteLine("Ticket eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el Ticket.");
        }
    }
    private static void ShowTickets()
    {
        var tickets = DataStore.Tickets.ToList(); //Get all Tickets
        foreach (var ticket in tickets)
        {
            Console.WriteLine($"ID[{ticket.TicketId}] | ClienteId:[{ticket.ClientId}] ConciertoId:[{ticket.ConcertId}] Cantidad:[{ticket.TicketAmount}] Precio Total:[{ticket.TicketPriceTotal}]");
        }
    }
}
