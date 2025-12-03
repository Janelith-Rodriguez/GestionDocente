using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/InscripcionesCarrera")]
    public class InscripcionesCarreraController : ControllerBase
    {
        private readonly IInscripcionCarreraRepositorio repositorio;

        public InscripcionesCarreraController(IInscripcionCarreraRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/InscripcionesCarrera
        public async Task<ActionResult<List<InscripcionCarrera>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/InscripcionesCarrera/2
        public async Task<ActionResult<InscripcionCarrera>> Get(int id)
        {
            InscripcionCarrera? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByAlumno/{alumnoId}")] //api/InscripcionesCarrera/GetByAlumno/1
        public async Task<ActionResult<List<InscripcionCarrera>>> GetByAlumno(int alumnoId)
        {
            var entidades = await repositorio.SelectByAlumno(alumnoId);
            return entidades;
        }

        [HttpGet("GetByCarrera/{carreraId}")] //api/InscripcionesCarrera/GetByCarrera/1
        public async Task<ActionResult<List<InscripcionCarrera>>> GetByCarrera(int carreraId)
        {
            var entidades = await repositorio.SelectByCarrera(carreraId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/InscripcionesCarrera/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(InscripcionCarrera entidad)
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

        [HttpPut("{id:int}")] //api/InscripcionesCarrera/2
        public async Task<ActionResult> Put(int id, [FromBody] InscripcionCarrera entidad)
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
                    return BadRequest("No se pudo actualizar la inscripción a carrera");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/InscripcionesCarrera/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La inscripción a carrera no se pudo borrar");
            }
            return Ok();
        }
    }
}
