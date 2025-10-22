using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Mascota
{
    [Key] public int IdMascota { get; set; }
    [MaxLength(100)] public string Nombre { get; set; }
    [MaxLength(100)] public string Especie { get; set; }
    public int Edad { get; set; }

    public Mascota()
    {
    }

    public Mascota(int idMascota, string nombre, string especie, int edad) //Constructor
    {
        IdMascota = idMascota;
        Nombre = nombre;
        Especie = especie;
        Edad = edad;
    }
}