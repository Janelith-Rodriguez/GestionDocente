using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Turnos")]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoRepositorio repositorio;

        public TurnosController(ITurnoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Turnos
        public async Task<ActionResult<List<Turno>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Turnos/2
        public async Task<ActionResult<Turno>> Get(int id)
        {
            Turno? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByMateria/{materiaPlanId}")] //api/Turnos/GetByMateria/1
        public async Task<ActionResult<List<Turno>>> GetByMateria(int materiaPlanId)
        {
            var entidades = await repositorio.SelectByMateriaPlan(materiaPlanId);
            return entidades;
        }

        [HttpGet("GetByProfesor/{profesorId}")] //api/Turnos/GetByProfesor/1
        public async Task<ActionResult<List<Turno>>> GetByProfesor(int profesorId)
        {
            var entidades = await repositorio.SelectByProfesor(profesorId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Turnos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Turno entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{id:int}")] //api/Turnos/2
        public async Task<ActionResult> Put(int id, [FromBody] Turno entidad)
        {
            try
            {
                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var resultado = await repositorio.Update(id, entidad);

                if (!resultado)
                {
                    return BadRequest("No se pudo actualizar el turno");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Turnos/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El turno no se pudo borrar");
            }
            return Ok();
        }
    }
}
