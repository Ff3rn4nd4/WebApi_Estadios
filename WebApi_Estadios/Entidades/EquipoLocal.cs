namespace WebApi_Estadios.Entidades
{
    public class EquipoLocal
    {
        public int Id { get; set; }
        public string NombreEquipoL { get; set; }
        public string CiudadLocal { get; set; }
        //relacionando datos
        public int PartidoId { get; set; }
        public Partido Partido { get; set; }
    }
}
