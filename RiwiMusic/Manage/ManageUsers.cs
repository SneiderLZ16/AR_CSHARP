namespace RiwiMusic.Manage;
public static class ManageUsers
{
    public static void ManageUsersMenu()
    {
        bool menu = true;
        do
        {
            Console.WriteLine("\n===== Menú Administrar Usuarios =====");
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
                    Console.WriteLine("\n=== Crear Usuario ===");
                    CreateUser();
                    break;
                case 2:
                    Console.WriteLine("\n=== Editar Usuario ===");
                    EditUser();
                    break;
                case 3:
                    Console.WriteLine("\n=== Eliminar Usuario ===");
                    DeleteUser();
                    break;
                case 4:
                    Console.WriteLine("\n=== Mostrar Usuarios ===");
                    ShowUsers();
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
    private static void CreateUser()
    {   //Get name, email, password, status
        Console.Write("Ingrese nombre del usuario: ");
        string? name = Console.ReadLine();
        Console.Write("Ingrese correo del usuario: ");
        string? email = Console.ReadLine();
        Console.Write("Ingrese contraseña: ");
        string? password = Console.ReadLine();
        Console.Write("¿Permisos de Administrador? (s/n): ");
        bool status = Console.ReadLine()!.ToLower() == "s";
        
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("Datos inválidos, intente de nuevo.");
            return;
        }
        AddUser(name, email, password, status); //Send data to AddUser
    }
    private static void AddUser(string name, string email, string password, bool status)
    {
        var newUser = new Models.User()
        {
            UserId = DataStore.IdCounterU++,
            UserName = name,
            UserPassword = password,
            UserEmail = email,
            UserStatus = status
        };
        DataStore.Users.Add(newUser); //Add newUser to Users
        Console.WriteLine("Usuario creado correctamente.");
    }
    private static void EditUser()
    {
        Console.Write("\nIngrese el ID del cliente a editar: ");
        int idEdit = int.Parse(Console.ReadLine()!);
        
        var user = DataStore.Users.FirstOrDefault(user => user.UserId == idEdit);
        if (user != null)
        {   //Get new data to Update user
            Console.Write("Nuevo nombre: ");
            user.UserName = Console.ReadLine()!;

            Console.Write("Nuevo correo: ");
            user.UserEmail = Console.ReadLine()!;

            Console.Write("Nueva contraseña: ");
            user.UserPassword = Console.ReadLine()!;

            Console.Write("¿Permisos de Administrador? (s/n): ");
            user.UserStatus = Console.ReadLine()!.ToLower() == "s";

            Console.WriteLine("Usuario actualizado.");
        }
        else
        {
            Console.WriteLine("No se encontró el usuario.");
        }
    }
    private static void DeleteUser()
    {
        Console.Write("\nIngrese el ID del Usuario a eliminar: ");
        int idClear = Convert.ToInt32(Console.ReadLine());
        
        var user = DataStore.Users.FirstOrDefault(user => user.UserId == idClear);
        if (user != null)
        {
            DataStore.Users.Remove(user);
            Console.WriteLine("Usuario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontró el Usuario.");
        }
    }
    private static void ShowUsers()
    {
        var users = DataStore.Users.ToList(); //Get all Users
        foreach (var user in users)
        {
            Console.WriteLine($"ID[{user.UserId}] | Nombre usuario:[{user.UserName}] Correo: [{user.UserEmail}] Permisos: [{user.UserStatus}]");
        }
    }
}