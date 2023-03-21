using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Estadios.Entidades;

namespace WebApi_Estadios.Controllers
{
    //validaciones automaticas
    [ApiController]
    //Ruteo
    [Route("api/EquiposVisitantes")]

    public class EquiposVisitantesController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EquiposVisitantesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        //metodo get
        [HttpGet]
        public async Task<ActionResult<List<EquipoVisitante>>> GetAll()
        {
            return await dbContext.EquiposVisitantes.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipoVisitante>> GetById(int id)
        {
            {
                return await dbContext.EquiposVisitantes.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        //metodo post
        [HttpPost]
        public async Task<ActionResult> Post(EquipoVisitante equipoVisitante)
        {
            var existePartido = await dbContext.EquiposVisitantes.AnyAsync(x => x.Id == equipoVisitante.PartidoId);

            if (!existePartido)
            {
                return BadRequest($"No existe algun partido con esa Id: {equipoVisitante.PartidoId} ");
            }

            dbContext.Add(equipoVisitante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(EquipoVisitante equipoVisitante, int id)
        {
            var exist = await dbContext.EquiposVisitantes.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El estadio ingresado no existe");
            }

            if (equipoVisitante.PartidoId != id)
            {
                return BadRequest("El id del partido no coincide con el establecido en la url");
            }

            dbContext.Update(equipoVisitante);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.EquiposVisitantes.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("Recurso no encontrado");
            }

            dbContext.Remove(new EquipoVisitante { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
