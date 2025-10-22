using RiwiMusic.Models;
namespace RiwiMusic;

public static class User
{
    public static void Menu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Usuario =====");
            Console.WriteLine("1. Ver Conciertos");
            Console.WriteLine("2. Comprar Tickets");
            Console.WriteLine("3. Ver mis Tickets");
            Console.WriteLine("0. Cerrar Sesion");

            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Ver Conciertos");
                    ShowConcerts();
                    break;
                case 2:
                    Console.WriteLine("Comprar Tickets");
                    BuyTicket();
                    break;
                case 3:
                    Console.WriteLine("Ver mis Tickets");
                    ViewMyTickets();
                    break;
                case 0:
                    Console.WriteLine("Cerrar Sesion");
                    Login.Menu();
                    menu = false;
                    break;
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
            }
        } while (menu);
    }

    private static void ShowConcerts()
    {
        Console.WriteLine("\n===== Lista de Conciertos =====");
        foreach (var concert in DataStore.Concerts)
        {
            Console.WriteLine(@$"[{concert.ConcertId}] | Nombre: {concert.ConcertName}, Lugar: {concert.ConcertCity}
            Fecha: {concert.ConcertDate}, Precio: {concert.ConcertPrice} C/u");
        }
    }

    private static void BuyTicket()
    {
        ShowConcerts();
        Console.WriteLine("\nQuieres comprar? s/n");
        bool option = (Console.ReadLine()?.ToLower() == "s");

        if (option)
        {
            Buy();
        }
        else
        {
            Menu();
        }
    }

    private static void Buy()
    {
        Console.WriteLine("=== Comprar Ticket ===");
        Console.Write("Ingresa el numero de Concierto: ");
        var concertId = int.Parse(Console.ReadLine()!);
        Console.Write("Cantidad de tickets: ");
        var amount = int.Parse(Console.ReadLine()!);
        double priceTotal = 0;
        foreach (var c in DataStore.Concerts)
        {
            if (c.ConcertId == concertId)
            {
                priceTotal += c.ConcertPrice;
            }
        }

        var newTicket = new Ticket()
        {
            TicketId = DataStore.IdCounterT++,
            ClientId = Login.LoggedUserId,
            ConcertId = concertId,
            TicketAmount = amount,
            TicketPriceTotal = priceTotal * amount,
        };
        DataStore.Tickets.Add(newTicket);
        Console.WriteLine("=== Comprar Realizada ===");
    }

    private static void ViewMyTickets() //Get all tickets for User
    {
        Console.WriteLine("=== Mis Tickets ===");
        var ticketsClient = from t in DataStore.Tickets
            join c in DataStore.Concerts 
                on t.ConcertId equals c.ConcertId
            where t.ClientId == Login.LoggedUserId
            select new
            {
                t.TicketId,
                t.TicketAmount,
                t.TicketPriceTotal,
                c.ConcertName
            };
        foreach (var item in ticketsClient)
        {
            Console.WriteLine($"TicketId: {item.TicketId} | Concierto: {item.ConcertName} | Cantidad: {item.TicketAmount} | Total: {item.TicketPriceTotal}");
        }
    }
}