using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Menus;

public class MenuAtenciones
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE ATENCIONES ===");
            Console.WriteLine("1. Registrar atención");
            Console.WriteLine("2. Listar atenciones");
            Console.WriteLine("3. Editar atención");
            Console.WriteLine("4. Eliminar atención");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarAtencion();
                    break;
                case "2":
                    ListarAtenciones();
                    break;
                case "3":
                    EditarAtencion();
                    break;
                case "4":
                    EliminarAtencion();
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

    private void RegistrarAtencion()
    {
        var contex = new AppDbContext();
        var service = new AtencionService(contex);

    Console.WriteLine("\n=== REGISTRAR ATENCIÓN ===");
    Console.Write("Ingrese el id de la atención: ");
    int atencionId = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese la fecha de la atención (yyyy-MM-dd): ");
    DateTime fecha = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el problema de la atención: ");
    string problema = Console.ReadLine();
    Console.WriteLine("Ingrese el id de la mascota: ");
    int mascotaId = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese el id del veterinario: ");
    int veterinarioId = int.Parse(Console.ReadLine());

    var nuevaAtencion = new Atencion(atencionId, fecha, problema, mascotaId, veterinarioId);
    service.Registrar(nuevaAtencion);
    Console.Write("Atención agregada correctamente.");
    }

    private async void ListarAtenciones()
    {
        var contex = new AppDbContext();
        var service = new AtencionService(contex);

        Console.WriteLine("\n=== LISTADO ATENCIONES ===");
        IEnumerable<Atencion> atenciones = await service.Listar();
        foreach (var atencion in atenciones)
        {
            Console.WriteLine($"ID:[{atencion.IdAtencion}], Fecha:[{atencion.Fecha:yyyy-MM-dd}], Problema:[{atencion.Problema}], Mascota:[{atencion.MascotaId}], Veterinario:[{atencion.VeterinarioId}]");
        }

        Console.WriteLine("Atenciones listadas correctamente.");
    }

    private async void EditarAtencion()
    {
        var contex = new AppDbContext();
        var service = new AtencionService(contex);

        ListarAtenciones();

    Console.WriteLine("\n=== EDITAR ATENCIÓN ===");
    Console.Write("Ingrese el ID de la atención a editar: ");
    int atencionId = int.Parse(Console.ReadLine());
    Console.Write("Ingrese la NUEVA fecha de la atención (yyyy-MM-dd): ");
    DateTime fecha = DateTime.Parse(Console.ReadLine());
    Console.Write("Ingrese el NUEVO problema: ");
    string problema = Console.ReadLine();
    Console.Write("Ingrese el NUEVO id de la mascota: ");
    int mascotaId = int.Parse(Console.ReadLine());
    Console.Write("Ingrese el NUEVO id del veterinario: ");
    int veterinarioId = int.Parse(Console.ReadLine());

    var atencionParaActualizar = new Atencion(atencionId, fecha, problema, mascotaId, veterinarioId);
    Atencion atencionEditada = await service.Editar(atencionParaActualizar);

    Console.Write("Atención editada correctamente.");
    }

    public void EliminarAtencion()
    {
        var contex = new AppDbContext();
        var service = new AtencionService(contex);

        ListarAtenciones();

        Console.WriteLine("\n=== ELIMINAR ATENCIÓN ===");
        Console.Write("Ingrese el id de la atención: ");
        int atencionId = int.Parse(Console.ReadLine());

        bool task = service.Eliminar(atencionId);
        if (task)
        {
            Console.WriteLine("Atención eliminada correctamente.");
        }
        else
        {
            Console.WriteLine("Atención no existe en el sistema.");
        }
    }
}
