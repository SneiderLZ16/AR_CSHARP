namespace Veterinaria.Menus;

public class Menu
{
    public void Mostrar()
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Gestion Clientes");
            Console.WriteLine("2. Gestion Veterinarios");
            Console.WriteLine("3. Gestion Mascotas");
            Console.WriteLine("4. Gestion Atenciones");
            Console.WriteLine("5. Consultas Avanzadas");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    GestionClientes();
                    break;
                case "2":
                    GestionVeterinarios();
                    break;
                case "3":
                    GestionMascotas();
                    break;
                case "4":
                    GestionAtenciones();
                    break;
                case "5":
                    ConsultasAvanzadas();
                    break;
                case "0":
                    salir = true;
                    Console.WriteLine("Saliendo del programa Veterinaria...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void GestionClientes()
    {
        MenuClientes menu = new MenuClientes();
        menu.Mostrar();
    }

    private void GestionVeterinarios()
    {
        MenuVeterinarios menu = new MenuVeterinarios();
        menu.Mostrar();
    }

    private void GestionMascotas()
    {
        MenuMascotas menu = new MenuMascotas();
        menu.Mostrar();
    }

    private void GestionAtenciones()
    {
        MenuAtenciones menu = new MenuAtenciones();
        menu.Mostrar();
    }
    
    private void ConsultasAvanzadas()
    {
        MenuConsultasAvanzadas menu = new MenuConsultasAvanzadas();
        menu.Mostrar();
    }
}