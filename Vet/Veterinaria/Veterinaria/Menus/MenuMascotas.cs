using Veterinaria.Data;
using Veterinaria.Models;
using Veterinaria.Services;

namespace Veterinaria.Menus;

public class MenuMascotas
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== GESTIÓN DE MASCOTAS ===");
            Console.WriteLine("1. Registrar mascota");
            Console.WriteLine("2. Listar mascotas");
            Console.WriteLine("3. Editar mascota");
            Console.WriteLine("4. Eliminar mascota");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarMascota();
                    break;
                case "2":
                    ListarMascotas();
                    break;
                case "3":
                    EditarMascota();
                    break;
                case "4":
                    EliminarMascota();
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

    private void RegistrarMascota()
    {
        var contex = new AppDbContext();
        var service = new MascotaService(contex);

        Console.WriteLine("\n=== REGISTRAR MASCOTA ===");
        Console.Write("Ingrese el id de la mascota: ");
        int mascotaId = int.Parse(Console.ReadLine());
        Console.WriteLine("Ingrese el nombre de la mascota: ");
        string nombre = Console.ReadLine();
        Console.WriteLine("Ingrese la especie de la mascota: ");
        string especie = Console.ReadLine();
        Console.WriteLine("Ingrese la edad de la mascota: ");
        int edad = int.Parse(Console.ReadLine());

        var nuevaMascota = new Mascota(mascotaId, nombre, especie, edad);
        service.Registrar(nuevaMascota);
        Console.Write("Mascota agregada correctamente.");
    }

    private async void ListarMascotas()
    {
        var contex = new AppDbContext();
        var service = new MascotaService(contex);

        Console.WriteLine("\n=== LISTADO MASCOTAS ===");
        IEnumerable<Mascota> mascotas = await service.Listar();
        foreach (var mascota in mascotas)
        {
            Console.WriteLine($"ID:[{mascota.IdMascota}], Nombre:[{mascota.Nombre}], Especie:[{mascota.Especie}], Edad:[{mascota.Edad}]");
        }

        Console.WriteLine("Mascotas listadas correctamente.");
    }

    private async void EditarMascota()
    {
        var contex = new AppDbContext();
        var service = new MascotaService(contex);

        ListarMascotas();

        Console.WriteLine("\n=== EDITAR MASCOTA ===");
        Console.Write("Ingrese el ID de la mascota a editar: ");
        int mascotaId = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el NUEVO nombre de la mascota: ");
        string nombre = Console.ReadLine();
        Console.Write("Ingrese la NUEVA especie de la mascota: ");
        string especie = Console.ReadLine();
        Console.Write("Ingrese la NUEVA edad de la mascota: ");
        int edad = int.Parse(Console.ReadLine());

        var mascotaParaActualizar = new Mascota(mascotaId, nombre, especie, edad);
        Mascota mascotaEditada = await service.Editar(mascotaParaActualizar);

        Console.Write("Mascota editada correctamente.");
    }

    public void EliminarMascota()
    {
        var contex = new AppDbContext();
        var service = new MascotaService(contex);

        ListarMascotas();

        Console.WriteLine("\n=== ELIMINAR MASCOTA ===");
        Console.Write("Ingrese el id de la mascota: ");
        int mascotaId = int.Parse(Console.ReadLine());

        bool task = service.Eliminar(mascotaId);
        if (task)
        {
            Console.WriteLine("Mascota eliminada correctamente.");
        }
        else
        {
            Console.WriteLine("Mascota no existe en el sistema.");
        }
    }
}
