using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Clases")]
    public class ClasesControllers : ControllerBase
    {
        private readonly Context context;

        public ClasesControllers(Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clase>>> Get() 
        {
            return await context.Clases.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clase>> GetById(int id)
        {
            //Busca la clase en la basse de datos utilizando el ID
            var clase = await context.Clases.FindAsync(id);

            //si no se encuentra la clase, devuelve un error 404
            if (clase == null)
            {
                return NotFound($"No se encontro la clase con el ID {id}.");
            }

            //si la clase existe, devuelve la informacion de la clase
            return Ok(clase);

        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Post(Clase entidad)
        {
            try
            {
                context.Clases.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id:int}")] //api/Clase/
        public async Task<ActionResult>Put(int id, [FromBody] Clase entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var d = await context.Clases.
                          Where(e => e.Id == id)
                          .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe la clase buscada.");
            }
            d.Turno=entidad.Turno;
            d.Fecha = entidad.Fecha;
            d.Activo=entidad.Activo;

            try
            {
                context.Clases.Update(d);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Clases.AnyAsync(x => x.Id==id); 
            if (!existe)
            {
                return NotFound($"La clase {id} no existe.");
            }
            Clase EntidadABorrar = new Clase();
            EntidadABorrar.Id = id;

            context.RemoveRange(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
            
        }
    }
}
