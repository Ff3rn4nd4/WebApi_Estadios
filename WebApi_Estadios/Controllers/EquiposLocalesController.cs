using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_Estadios.Entidades;

namespace WebApi_Estadios.Controllers
{
    
    //validaciones automaticas
    [ApiController]
    //Ruteo
    [Route("api/EquiposLocales")]
    public class EquiposLocalesController: ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EquiposLocalesController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        //metodo get
        [HttpGet("Lista")]
        public async Task<ActionResult<List<EquipoLocal>>> GetAll()
        {
            return await dbContext.EquiposLocales.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipoLocal>> GetById(int id)
        {
                return await dbContext.EquiposLocales.FirstOrDefaultAsync(x => x.Id == id);
        }
        //metodo post
        [HttpPost]
        public async Task<ActionResult> Post(EquipoLocal equipoLocal)
        {
            var existePartido = await dbContext.Partidos.AnyAsync(x => x.Id == equipoLocal.PartidoId);

            if (!existePartido)
            {
                return BadRequest($"No existe algun partido con esa Id: {equipoLocal.PartidoId} ");
            }

            dbContext.Add(equipoLocal);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(EquipoLocal equipoLocal, int id)
        {
            var exist = await dbContext.EquiposLocales.AnyAsync(x => x.Id == id);

            if (!exist)
            {
                return NotFound("El equipo ingresado no existe");
            }

            if (equipoLocal.PartidoId != id)
            {
                return BadRequest("El id del partido no coincide con el establecido en la url");
            }

            dbContext.Update(equipoLocal);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        //metodo delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.EquiposLocales.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("Recurso no encontrado");
            }

            dbContext.Remove(new EquipoLocal { Id = id });
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
