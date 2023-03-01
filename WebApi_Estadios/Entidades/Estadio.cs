﻿namespace WebApi_Estadios.Entidades
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public int PartidoId { get; set; }
        public Partido Partido { get; set; }


    }
}
