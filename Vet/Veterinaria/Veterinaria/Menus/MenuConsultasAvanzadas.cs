/*

using System;
using System.Linq;
using Veterinaria.Data;
using Veterinaria.Models;

namespace Veterinaria.Menus;

public class MenuConsultasAvanzadas
{
    public void Mostrar()
    {
        bool volver = false;
        while (!volver)
        {
            Console.Clear();
            Console.WriteLine("=== CONSULTAS AVANZADAS ===");
            Console.WriteLine("1. Consultar todas las mascotas de un cliente");
            Console.WriteLine("2. Consultar el veterinario con más atenciones realizadas");
            Console.WriteLine("3. Consultar la especie de mascota más atendida en la clínica");
            Console.WriteLine("4. Consultar el cliente con más mascotas registradas");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");

            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultarMascotasDeCliente();
                    break;
                case "2":
                    ConsultarVeterinarioMasAtenciones();
                    break;
                case "3":
                    ConsultarEspecieMasAtendida();
                    break;
                case "4":
                    ConsultarClienteMasMascotas();
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

    private void ConsultarMascotasDeCliente()
    {
        var context = new AppDbContext();
        Console.Write("Ingrese el ID del cliente: ");
        int clienteId = int.Parse(Console.ReadLine());
        var mascotas = context.Mascotas.Where(m => m.ClienteId == clienteId).ToList();
        Console.WriteLine($"Mascotas del cliente {clienteId}:");
        foreach (var mascota in mascotas)
        {
            Console.WriteLine($"ID: {mascota.IdMascota}, Nombre: {mascota.Nombre}, Especie: {mascota.Especie}");
        }
    }

    private void ConsultarVeterinarioMasAtenciones()
    {
        var context = new AppDbContext();
        var consulta = context.Atenciones
            .GroupBy(a => a.VeterinarioId)
            .Select(g => new { VeterinarioId = g.Key, Total = g.Count() })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault();
        if (consulta != null)
        {
            var vet = context.Veterinarios.Find(consulta.VeterinarioId);
            Console.WriteLine($"Veterinario con más atenciones: {vet.Nombre} {vet.Apellido} (ID: {vet.IdVeterinario}) - Total: {consulta.Total}");
        }
        else
        {
            Console.WriteLine("No hay atenciones registradas.");
        }
    }

    private void ConsultarEspecieMasAtendida()
    {
        var context = new AppDbContext();
        var consulta = context.Atenciones
            .Join(context.Mascotas, a => a.MascotaId, m => m.IdMascota, (a, m) => m.Especie)
            .GroupBy(e => e)
            .Select(g => new { Especie = g.Key, Total = g.Count() })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault();
        if (consulta != null)
        {
            Console.WriteLine($"Especie más atendida: {consulta.Especie} - Total: {consulta.Total}");
        }
        else
        {
            Console.WriteLine("No hay atenciones registradas.");
        }
    }

    private void ConsultarClienteMasMascotas()
    {
        var context = new AppDbContext();
        var consulta = context.Mascotas
            .GroupBy(m => m.ClienteId)
            .Select(g => new { ClienteId = g.Key, Total = g.Count() })
            .OrderByDescending(x => x.Total)
            .FirstOrDefault();
        if (consulta != null)
        {
            var cliente = context.Clientes.Find(consulta.ClienteId);
            Console.WriteLine($"Cliente con más mascotas: {cliente.Nombre} {cliente.Apellido} (ID: {cliente.IdCliente}) - Total: {consulta.Total}");
        }
        else
        {
            Console.WriteLine("No hay mascotas registradas.");
        }
    }
}
*/