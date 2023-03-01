namespace WebApi_Estadios.Entidades
{
    public class Partido
    {
        public int Id { get; set;}
        public string Fecha { get; set;}
        public string Hora { get; set;}
        //FK 
        public List<Estadio> estadios { get; set; }
        

    }
}
