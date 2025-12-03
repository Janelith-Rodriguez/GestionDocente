using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Profesores")]
    public class ProfesoresController : ControllerBase
    {
        private readonly IProfesorRepositorio repositorio;

        public ProfesoresController(IProfesorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Profesores
        public async Task<ActionResult<List<Profesor>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Profesores/2
        public async Task<ActionResult<Profesor>> Get(int id)
        {
            Profesor? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByUsuario/{usuarioId}")] //api/Profesores/GetByUsuario/5
        public async Task<ActionResult<Profesor>> GetByUsuario(int usuarioId)
        {
            Profesor? entidad = await repositorio.SelectByUsuario(usuarioId);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/Profesores/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Profesor entidad)
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

        [HttpPut("{id:int}")] //api/Profesores/2
        public async Task<ActionResult> Put(int id, [FromBody] Profesor entidad)
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
                    return BadRequest("No se pudo actualizar el profesor");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Profesores/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El profesor no se pudo borrar");
            }
            return Ok();
        }
    }
}
