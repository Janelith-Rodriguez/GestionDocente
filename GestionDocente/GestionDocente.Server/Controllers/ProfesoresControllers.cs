using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Profesores")]
    public class ProfesoresControllers : ControllerBase
    {
        private readonly Context context;

        public ProfesoresControllers(Context context)
        {
            this.context = context;
        }

        #region Peticiones Get

        [HttpGet]  //api/Profesores
        public async Task<ActionResult<List<Profesor>>> Get()
        {
            return await context.Profesores.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesor>> Get(int id)
        {
            Profesor? d = await context.Profesores
                              .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }

        [HttpGet("existe/{id:int}")] //api/Profesores/existe
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Profesores.AnyAsync(x => x.Id == id);
            return existe;

        }

        #endregion

        [HttpPost]
        public async Task<ActionResult<int>> Post(Profesor entidad)
        {
            try
            {
                context.Profesores.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Profesor entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await context.Profesores
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe la orden buscado");
            }

            d.Usuario = entidad.Usuario;
            d.Estado = entidad.Estado;
            d.Activo = entidad.Activo;
            try
            {
                context.Profesores.Update(d);
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
            var existe = await context.Profesores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El profesor {id} no existe");
            }
            Profesor EntidadABorrar = new Profesor();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
