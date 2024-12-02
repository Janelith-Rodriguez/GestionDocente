using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Turnos")]
    public class TurnosControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public TurnosControllers(Context context,
                                 IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Turno>>> Get()
        {
            return await context.Turnos.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Turno>> GetById(int id)
        {
            Turno? d = await context.Turnos
                              .FirstOrDefaultAsync(x => x.Id == id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }
        #region Peticiones Get

        //[HttpGet]
        //public async Task<ActionResult<List<Turno>>> Get()
        //{
        //    return await repositorio.Select();
        //}

        //[HttpGet("{id:int}")]
        //public async Task<ActionResult<Turno>> Get(int id)
        //{
        //    Turno? sel = await repositorio.SelectById(id);
        //    if (sel == null)
        //    {
        //        return NotFound();
        //    }
        //    return sel;
        //}

        //[HttpGet("existe/{id:int}")]
        //public async Task<ActionResult<bool>> Existe(int id)
        //{
        //    var existe = await repositorio.Existe(id);
        //    return existe;

        //}

        #endregion

        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTurnoDTO entidadDTO)
        {
            try
            {
                //Turno entidad = new Turno();
                //entidad.Sede = entidadDTO.Sede;
                //entidad.Horario = entidadDTO.Horario;
                //entidad.AnnoCicloLectivo = entidadDTO.AnnoCicloLectivo;

                Turno entidad = mapper.Map<Turno>(entidadDTO);

                context.Turnos.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Turno entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await context.Turnos
                                  .Where(reg => reg.Id == id)
                                  .FirstOrDefaultAsync();
            if (d == null)
            {
                return NotFound("No existe el turno buscado");
            }

            d.Profesor = entidad.Profesor;
            d.Sede = entidad.Sede;
            d.Horario = entidad.Horario;
            d.AnnoCicloLectivo = entidad.AnnoCicloLectivo;
            d.Activo = entidad.Activo;
            try
            {
                context.Turnos.Update(d);
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
            var existe = await context.Turnos.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"El usuario {id} no existe");
            }
            Turno EntidadABorrar = new Turno();
            EntidadABorrar.Id = id;

            context.Remove(EntidadABorrar);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
