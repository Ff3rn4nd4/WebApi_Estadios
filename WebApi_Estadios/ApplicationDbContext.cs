using Microsoft.EntityFrameworkCore;
using WebApi_Estadios.Entidades;

namespace WebApi_Estadios
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        { 

        }

        //Bases de datos 
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<EquipoLocal> EquiposLocales { get; set; }
        //public DbSet<EquipoVisitante> EquiposVisitantes { get; set; }
    }
}
