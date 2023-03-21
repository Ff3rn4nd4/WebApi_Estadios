using System.ComponentModel.DataAnnotations;

namespace WebApi_Estadios.Entidades
{
    public class EquipoVisitante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre del equipo es requerido")]
        public string NombreEquipoV { get; set; }
        public string CiudadVisitante { get; set; }
        // relacionando datos 
        public int PartidoId { get; set; }
        public Partido Partido { get; set; }
    }
}
