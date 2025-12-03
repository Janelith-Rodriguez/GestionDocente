using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/CertificadosAlumno")]
    public class CertificadosAlumnoController : ControllerBase
    {
        private readonly ICertificadoAlumnoRepositorio repositorio;

        public CertificadosAlumnoController(ICertificadoAlumnoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/CertificadosAlumno
        public async Task<ActionResult<List<CertificadoAlumno>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/CertificadosAlumno/2
        public async Task<ActionResult<CertificadoAlumno>> Get(int id)
        {
            CertificadoAlumno? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        // Métodos corregidos - usando los métodos que SÍ existen
        [HttpGet("GetByNombre/{nombre}")] //api/CertificadosAlumno/GetByNombre/NombreCertificado
        public async Task<ActionResult<List<CertificadoAlumno>>> GetByNombre(string nombre)
        {
            var entidades = await repositorio.SelectByNombre(nombre);
            return entidades;
        }

        [HttpGet("GetByDuracion/{duracion}")] //api/CertificadosAlumno/GetByDuracion/2 años
        public async Task<ActionResult<List<CertificadoAlumno>>> GetByDuracion(string duracion)
        {
            var entidades = await repositorio.SelectByDuracion(duracion);
            return entidades;
        }

        [HttpGet("GetByModalidad/{modalidad}")] //api/CertificadosAlumno/GetByModalidad/Presencial
        public async Task<ActionResult<List<CertificadoAlumno>>> GetByModalidad(string modalidad)
        {
            var entidades = await repositorio.SelectByModalidad(modalidad);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/CertificadosAlumno/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CertificadoAlumno entidad)
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

        [HttpPut("{id:int}")] //api/CertificadosAlumno/2
        public async Task<ActionResult> Put(int id, [FromBody] CertificadoAlumno entidad)
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
                    return BadRequest("No se pudo actualizar el certificado del alumno");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/CertificadosAlumno/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El certificado del alumno no se pudo borrar");
            }
            return Ok();
        }
    }
}