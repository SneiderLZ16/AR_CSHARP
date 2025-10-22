namespace RiwiMusic;
public static class Admin
{
    public static void Menu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Administrador =====");
            Console.WriteLine("1. Gestión de Usuarios");
            Console.WriteLine("2. Gestión de Conciertos");
            Console.WriteLine("3. Gestión de Tiquetes");
            Console.WriteLine("4. Consultas");
            Console.WriteLine("0. Cerrar Sesion ");
            
            Console.Write("Seleccione una opción: ");
            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Gestion de Usuarios");
                    Manage.ManageUsers.ManageUsersMenu();
                    break;
                case 2:
                    Console.WriteLine("Gestion de Conciertos");
                    Manage.ManageConcerts.ManageConcertsMenu();
                    break;
                case 3:
                    Console.WriteLine("Gestion de Tiquetes");
                    Manage.ManageTickets.ManageTicketsMenu();
                    break;
                case 4:
                    Console.WriteLine("Consultas");
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
}