using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Alumnos")]
    public class AlumnosController : ControllerBase
    {
        private readonly IAlumnoRepositorio repositorio;

        public AlumnosController(IAlumnoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Alumnos
        public async Task<ActionResult<List<Alumno>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Alumnos/2
        public async Task<ActionResult<Alumno>> Get(int id)
        {
            Alumno? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByUsuario/{usuarioId}")] //api/Alumnos/GetByUsuario/5
        public async Task<ActionResult<Alumno>> GetByUsuario(int usuarioId)
        {
            Alumno? entidad = await repositorio.SelectByUsuario(usuarioId);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("existe/{id:int}")] //api/Alumnos/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Alumno entidad)
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

        [HttpPut("{id:int}")] //api/Alumnos/2
        public async Task<ActionResult> Put(int id, [FromBody] Alumno entidad)
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
                    return BadRequest("No se pudo actualizar el alumno");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Alumnos/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El alumno no se pudo borrar");
            }
            return Ok();
        }
    }
}