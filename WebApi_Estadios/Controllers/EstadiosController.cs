using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Estadios.Entidades;

namespace WebApi_Estadios.Controllers
{
    //validaciones automaticas
    [ApiController]
    //Ruteo
    [Route("api/Estadios")]
    public class EstadiosController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
          
        public EstadiosController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        //metodo get
        [HttpGet]
        public async Task<ActionResult<List<Estadio>>> Get()
        {
            return await dbContext.Estadios.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Estadio>> GetById(int id)
        {
            return await dbContext.Estadios.FirstOrDefaultAsync(x => x.Id == id);
        }

        //metodo post
        [HttpPost]
        public async Task<ActionResult> Post(Estadio estadio)
        {
            var existePartido = await dbContext.Partidos.AnyAsync(x => x.Id == estadio.PartidoId);

            if (!existePartido)
            {
                return BadRequest($"No existe algun partido con esa Id: {estadio.PartidoId} ");
            }

            dbContext.Add(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Estadio estadio, int id)
        {
            var exist = await dbContext.Estadios.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El estadio ingresado no existe");
            }

            if (estadio.PartidoId != id)
            {
                return BadRequest("El id del partido no coincide con el establecido en la url");
            }

            dbContext.Update(estadio);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Estadios.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("Recurso no encontrado");
            }

            dbContext.Remove(new Estadio { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }

    }
}
