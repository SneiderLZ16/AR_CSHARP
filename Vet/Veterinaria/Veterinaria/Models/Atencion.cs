using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models;

public class Atencion
{
    [Key] public int IdAtencion { get; set; }
    public DateTime Fecha { get; set; }
    [MaxLength(100)] public string Problema { get; set; }
    public int MascotaId { get; set; }
    public int VeterinarioId { get; set; }

    public Atencion()
    {
    }

    public Atencion(int idAtencion, DateTime fecha, string problema, int mascotaId, int veterinarioId) //Constructor
    {
        IdAtencion = idAtencion;
        Fecha = fecha;
        Problema = problema;
        MascotaId = mascotaId;
        VeterinarioId = veterinarioId;
    }
}