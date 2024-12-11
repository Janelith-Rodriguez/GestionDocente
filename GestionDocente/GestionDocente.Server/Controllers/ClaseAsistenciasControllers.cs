using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/ClaseAsistencias")]
    public class ClaseAsistenciasControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ClaseAsistenciasControllers(Context context,
                                           IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaseAsistencia>>> Get()
        {
            return await context.ClasesAsistencias.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseAsistencia>> GetById(int id)
        {
            // Busca la clase asistencia en la base de datos utilizando el ID
            var claseAsistencia = await context.ClasesAsistencias.FindAsync(id);

            // Si no se encuentra la clase asistencia, devuelve un error 404
            if (claseAsistencia == null)
            {
                return NotFound($"No se encontró la clase asistencia con el ID {id}.");
            }

            // Si la clase asistencia existe, devuelve la información
            return Ok(claseAsistencia);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearClaseAsistenciaDTO entidadDTO)
        {
            try
            {
                var d = mapper.Map<ClaseAsistencia>(entidadDTO);
                //ClaseAsistencia entidad = new ClaseAsistencia();
                //entidad.Id = entidadDTO.Id;
                //entidad.Clase = entidadDTO.Clase;
                //entidad.Asistencia = entidadDTO.Asistencia;
                //entidad.Observacion= entidadDTO.Observacion;
                ClaseAsistencia entidad = mapper.Map<ClaseAsistencia>(entidadDTO);

                context.ClasesAsistencias.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id:int}")] //api/ClaseAsistencia/
        public async Task<ActionResult> Put(int id, [FromBody] ClaseAsistencia entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos Incorrectos");
            }
            var d = await context.ClasesAsistencias.
                          Where(e => e.Id == id)
                          .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe la claseasistencia buscada.");
            }
            d.Clase  = entidad.Clase;
            d.Asistencia = entidad.Asistencia;
            d.Observacion = entidad.Observacion;
            d.Activo = entidad.Activo;

            try
            {
                context.ClasesAsistencias.Update(d);
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
            var existe = await context.ClasesAsistencias.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La claseasistencia {id} no existe.");
            }
            ClaseAsistencia EntidadABorrar = new ClaseAsistencia();
            EntidadABorrar.Id = id;

            context.RemoveRange(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
    }
}
