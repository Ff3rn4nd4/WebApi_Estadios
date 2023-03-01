using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Estadios.Entidades;

namespace WebApi_Estadios.Controllers
{
    //validaciones automaticas
    [ApiController]
    //Ruteo
    [Route("api/partidos")]
    public class PartidosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PartidosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }


        /*metodo get con Datos Dummy
        [HttpGet]

        public ActionResult <List<Partido>> Get() 
        {
            return new List<Partido>()
            {
                new Partido() { Id= 1, Fecha = " 24 de febrero", Hora="7 pm"},
                new Partido() { Id=2, Fecha=" 2 de marzo", Hora="11 pm"}
            };
        }*/

        //metodo get
        [HttpGet]
        public async Task<ActionResult<List<Partido>>> Get()
        {
            return await dbContext.Partidos.Include(x => x.estadios).ToListAsync();
        }

        //metodo post
        [HttpPost]
        public async Task<ActionResult> Post(Partido partido) 
        {
            dbContext.Add(partido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Partido partido, int id)
        {
            if(partido.Id != id)
            {
                return BadRequest("El id de este partido no existe en la url");
            }

            dbContext.Update(partido);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Partidos.AnyAsync(x => x.Id == id);
            if(!exist)
            {
                return NotFound();
            }

            dbContext.Remove(new Partido()
            {
                Id = id
            });

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
