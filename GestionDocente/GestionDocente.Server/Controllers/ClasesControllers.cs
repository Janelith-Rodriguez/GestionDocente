using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
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

        [HttpGet] //api/Clases
        public async Task<ActionResult<List<Clase>>> Get()
        {
            return await context.Clases.ToListAsync();
        }

        [HttpGet("{id:int}")] //api/Clases2
        public async Task<ActionResult<Clase>> Get(int id)
        {
            Clase? d = await context.Clases
                              .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }

        //[HttpGet("{fech}")] //api/Clases/Año-Mes-Dia
        //public async Task<ActionResult<Clase>> GetByFecha(DateTime fech)
        //{
        //    Clase? d = await context.Clases
        //                      .FirstOrDefaultAsync(x => x.Fecha == fech);
        //    if (d == null)
        //    {
        //        return NotFound();
        //    }
        //    return d;
        //}

        [HttpGet("existe/{id:int}")] //api/Clases/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await context.Clases.AnyAsync(x => x.Id == id);
            return existe;
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
                throw;
            }
        }


        [HttpPut("{Id:int}")] //api/Clases2
        public async Task<ActionResult> Put(int id, [FromBody] Clase entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await context.Clases
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe la clase buscada");
            }

            d.Turno = entidad.Turno;
            d.Fecha = entidad.Fecha;
            d.Activo = entidad.Activo;
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

        [HttpDelete("{id:int}")] //api/Clases2
        public async Task<ActionResult> Delate(int id)
        {
            var existe = await context.Clases.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La clase {id} no existe");
            }
            Clase EntidadABorrar = new Clase();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
