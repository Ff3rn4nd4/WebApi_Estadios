using System.ComponentModel.DataAnnotations;

namespace WebApi_Estadios.Entidades
{
    public class Estadio
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del estadio es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La ubicacion del estadio es requerida")]
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public int PartidoId { get; set; }
        public Partido Partido { get; set; }


    }
}
