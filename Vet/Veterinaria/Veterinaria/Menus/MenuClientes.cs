using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Menus;

public class MenuClientes
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE CLIENTES ===");
            Console.WriteLine("1. Registrar cliente");
            Console.WriteLine("2. Listar clientes");
            Console.WriteLine("3. Editar cliente");
            Console.WriteLine("4. Eliminar cliente");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarCliente();
                    break;
                case "2":
                    ListarClientes();
                    break;
                case "3":
                    EditarCliente();
                    break;
                case "4":
                    EliminarCliente();
                    break;
                case "0":
                    volver = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }

            if (!volver)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private void RegistrarCliente()
    {
        var contex = new AppDbContext();
        var service = new ClienteService(contex);

        Console.WriteLine("\n=== REGISTRAR CLIENTE ==="); //Pedir todos los datos del nuevo cliente
        Console.Write("Ingrese el id del cliente: ");
        int clienteId = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el nombre del cliente: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el apellido del cliente: ");
        string apellido = Console.ReadLine();
        Console.WriteLine("Ingrese la edad del cliente: ");
        int edad = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el numero de telefono del cliente: ");
        string telefono = Console.ReadLine();
        Console.WriteLine("Ingrese el correo electronico del cliente: ");
        string correoElectronico = Console.ReadLine();

        //Crear el objeto Cliente
        var nuevoCliente = new Cliente(clienteId, nombre, apellido, edad, telefono, correoElectronico);
        service.Registrar(nuevoCliente);
        Console.Write("Cliente agregado correctamente.");
    }

    private async void ListarClientes()
    {
        var contex = new AppDbContext();
        var service = new ClienteService(contex);

        Console.WriteLine("\n=== LISTADO CLIENTES ===");
        IEnumerable<Cliente> clientes = await service.Listar(); //Obtener los clientes de la db
        foreach (var cliente in clientes)
        {
            Console.WriteLine( //Mostrar la lista con datos de los clientes
                $"ID:[{cliente.IdCliente}], Nombre:[{cliente.Nombre}{cliente.Apellido}] - {cliente.CorreoElectronico}");
        }

        Console.WriteLine("Clientes listados correctamente.");
    }

    private async void EditarCliente()
    {
        var contex = new AppDbContext();
        var service = new ClienteService(contex);

        ListarClientes(); //Mostrar clientes

        Console.WriteLine("\n=== EDITAR CLIENTE ==="); //Pedir todos los datos del nuevo cliente
        Console.Write("Ingrese el ID del cliente a editar: ");
        var clienteId = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el NUEVO nombre del cliente: ");
        string nombre = Console.ReadLine() ?? string.Empty;
        Console.Write("Ingrese el NUEVO apellido del cliente: ");
        string apellido = Console.ReadLine() ?? string.Empty;
        Console.Write("Ingrese la NUEVA edad del cliente: ");
        int edad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el NUEVO teléfono del cliente: ");
        string telefono = Console.ReadLine() ?? string.Empty;
        Console.Write("Ingrese el NUEVO correo electrónico del cliente: ");
        string correoElectronico = Console.ReadLine() ?? string.Empty;

        //Crear el objeto Cliente actualizado
        var clienteParaActualizar = new Cliente(clienteId, nombre, apellido, edad, telefono, correoElectronico);
        Cliente clienteEditado = await service.Editar(clienteParaActualizar);

        Console.Write("Cliente editado correctamente.");
    }

    public void EliminarCliente()
    {
        var contex = new AppDbContext();
        var service = new ClienteService(contex);

        ListarClientes(); //Mostrar clientes

        Console.WriteLine("\n=== ELIMINAR CLIENTE ==="); //Pedir ID del cliente a eliminar
        Console.Write("Ingrese el id del cliente: ");
        int clienteId = int.Parse(Console.ReadLine());

        bool task = service.Eliminar(clienteId); //Validar la eliminación
        if (task)
        {
            Console.WriteLine("Cliente eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Cliente no existe en el sistema.");
        }
    }
}