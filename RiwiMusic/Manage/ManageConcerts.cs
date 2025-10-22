using RiwiMusic.Models;
namespace RiwiMusic.Manage;
public static class ManageConcerts
{
    public static void ManageConcertsMenu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Administrar Conciertos =====");
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
                    Console.WriteLine("\n=== Crear Concierto ===");
                    CreateConcert();
                    break;
                case 2:
                    Console.WriteLine("\n=== Editar Concierto ===");
                    EditConcert();
                    break;
                case 3:
                    Console.WriteLine("\n=== Eliminar Concierto ===");
                    DeleteConcert();
                    break;
                case 4:
                    Console.WriteLine("\n=== Mostrar Conciertos ===");
                    ShowConcerts();
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
    private static void CreateConcert()
    {   //Get name, city, date, price
        Console.Write("Ingrese nombre del concierto: ");
        string? name = Console.ReadLine();

        Console.Write("Ingrese ciudad del concierto: ");
        string? city = Console.ReadLine();

        Console.Write("Ingrese fecha del concierto (AAAA-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Ingrese precio del concierto: ");
        double price = double.Parse(Console.ReadLine()!);

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("Datos inválidos, intente de nuevo.");
            return;
        }
        AddConcert(name, city, date, price); //Send data to AddConcert
    }
    private static void AddConcert(string name, string city, DateTime date, double price)
    {
        var newConcert = new Concert()
        {
            ConcertId = DataStore.IdCounterC++,
            ConcertName = name,
            ConcertCity = city,
            ConcertDate = date,
            ConcertPrice = price
        };
        DataStore.Concerts.Add(newConcert); //Add newConcert to Concerts
        Console.WriteLine("Concierto creado correctamente.");
    }
    private static void EditConcert()
    {
        Console.Write("\nIngrese el ID del concierto a editar: ");
        int idEdit = int.Parse(Console.ReadLine()!);
        
        var concert = DataStore.Concerts.FirstOrDefault(concert => concert.ConcertId == idEdit);
        if (concert != null)
        {   //Get new data to Update Concert
            Console.Write("Nuevo nombre: ");
            concert.ConcertName = Console.ReadLine()!;

            Console.Write("Nueva ciudad: ");
            concert.ConcertCity = Console.ReadLine()!;

            Console.Write("Nueva fecha: ");
            concert.ConcertDate = DateTime.Parse(Console.ReadLine()!);

            Console.Write("Nuevo precio: ");
            concert.ConcertPrice = double.Parse(Console.ReadLine()!);

            Console.WriteLine("Concierto actualizado.");
        }
        else
        {
            Console.WriteLine("No se encontró el concierto.");
        }
    }
    private static void DeleteConcert()
    {
        Console.Write("\nIngrese el ID del Concierto a eliminar: ");
        int idClear = Convert.ToInt32(Console.ReadLine());
        
        var concert = DataStore.Concerts.FirstOrDefault(concert => concert.ConcertId == idClear);
        if (concert != null)
        {
            DataStore.Concerts.Remove(concert);
            Console.WriteLine("Concierto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el Concierto.");
        }
    }
    private static void ShowConcerts()
    {
        var concerts = DataStore.Concerts.ToList(); //Get all Concerts
        foreach (var concert in concerts)
        {
            Console.WriteLine($"ID[{concert.ConcertId}] | Nombre concierto:[{concert.ConcertName}] Ciudad: [{concert.ConcertCity}] Fecha: [{concert.ConcertDate:yyyy-MM-dd}] Precio: [{concert.ConcertPrice}]");
        }
    }
}