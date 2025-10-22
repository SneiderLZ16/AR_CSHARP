using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Services;


namespace Veterinaria.Menus;

public class MenuVeterinarios
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE VETERINARIOS ===");
            Console.WriteLine("1. Registrar veterinario");
            Console.WriteLine("2. Listar veterinarios");
            Console.WriteLine("3. Editar veterinario");
            Console.WriteLine("4. Eliminar veterinario");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarVeterinario();
                    break;
                case "2":
                    ListarVeterinarios();
                    break;
                case "3":
                    EditarVeterinario();
                    break;
                case "4":
                    EliminarVeterinario();
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

    private void RegistrarVeterinario()
    {
        var contex = new AppDbContext();
        var service = new VeterinarioService(contex);

        Console.WriteLine("\n=== REGISTRAR VETERINARIO ===");
        Console.Write("Ingrese el id del veterinario: ");
        int veterinarioId = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el nombre del veterinario: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese el apellido del veterinario: ");
        string apellido = Console.ReadLine();
        Console.WriteLine("Ingrese la edad del veterinario: ");
        int edad = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese la especialidad del veterinario: ");
        string especialidad = Console.ReadLine();
        Console.WriteLine("Ingrese los años de experiencia: ");
        int aniosExp = int.Parse(Console.ReadLine());

        var nuevoVeterinario = new Veterinario(veterinarioId, nombre, apellido, edad, especialidad, aniosExp);
        service.Registrar(nuevoVeterinario);
        Console.Write("Veterinario agregado correctamente.");
    }

    private async void ListarVeterinarios()
    {
        var contex = new AppDbContext();
        var service = new VeterinarioService(contex);

        Console.WriteLine("\n=== LISTADO VETERINARIOS ===");
        IEnumerable<Veterinario> veterinarios = await service.Listar();
        foreach (var veterinario in veterinarios)
        {
            Console.WriteLine(
                $"ID:[{veterinario.IdVeterinario}], Nombre:[{veterinario.Nombre} {veterinario.Apellido}], Especialidad:[{veterinario.Especialidad}], Años de experiencia:[{veterinario.AniosExperiencia}]");
        }

        Console.WriteLine("Veterinarios listados correctamente.");
    }

    private async void EditarVeterinario()
    {
        var contex = new AppDbContext();
        var service = new VeterinarioService(contex);

        ListarVeterinarios();

        Console.WriteLine("\n=== EDITAR VETERINARIO ===");
        Console.Write("Ingrese el ID del veterinario a editar: ");
        int veterinarioId = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el NUEVO nombre del veterinario: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese el NUEVO apellido del veterinario: ");
        string apellido = Console.ReadLine();
        Console.Write("Ingrese la NUEVA edad del veterinario: ");
        int edad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese la NUEVA especialidad: ");
        string especialidad = Console.ReadLine();
        Console.Write("Ingrese los NUEVOS años de experiencia: ");
        int aniosExp = int.Parse(Console.ReadLine());

        var veterinarioParaActualizar = new Veterinario(veterinarioId, nombre, apellido, edad, especialidad, aniosExp);
        Veterinario veterinarioEditado = await service.Editar(veterinarioParaActualizar);

        Console.Write("Veterinario editado correctamente.");
    }

    public void EliminarVeterinario()
    {
        var contex = new AppDbContext();
        var service = new VeterinarioService(contex);

        ListarVeterinarios();

        Console.WriteLine("\n=== ELIMINAR VETERINARIO ===");
        Console.Write("Ingrese el id del veterinario: ");
        int veterinarioId = int.Parse(Console.ReadLine());

        bool task = service.Eliminar(veterinarioId);
        if (task)
        {
            Console.WriteLine("Veterinario eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Veterinario no existe en el sistema.");
        }
    }
}