using System.ComponentModel.DataAnnotations;

namespace WebApi_Estadios.Entidades
{
    public class Partido
    {
        public int Id { get; set;}
        //las validaciones van antes que entre el dato
        [Required(ErrorMessage = "El campo fecha es requerido")]
        public string Fecha { get; set;}
        [Required(ErrorMessage = "El campo hora es requerido")]
        public string Hora { get; set;}
        //FK 
        public List<Estadio> estadios { get; set; }
        public List<EquipoLocal> equiposLocales { get; set; }
        //public List<EquipoVisitante> equiposVisitantes { get; set; }

    }
}
