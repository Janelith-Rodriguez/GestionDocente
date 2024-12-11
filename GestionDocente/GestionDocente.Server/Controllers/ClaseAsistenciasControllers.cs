using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/ClaseAsistencias")]
    public class ClaseAsistenciasControllers : ControllerBase
    {
        private readonly IClaseAsistenciaRepositorio repositorio;
        private readonly IMapper mapper;

        public ClaseAsistenciasControllers(IClaseAsistenciaRepositorio repositorio,
                                           IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClaseAsistencia>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClaseAsistencia>> Get(int id)
        {
            // Busca la clase asistencia en la base de datos utilizando el ID
            ClaseAsistencia? d = await repositorio.SelectById(id);

            // Si no se encuentra la clase asistencia, devuelve un error 404
            if (d == null)
            {
                return NotFound($"No se encontró la clase asistencia con el ID {id}.");
            }

            // Si la clase asistencia existe, devuelve la información
            return d;
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            var existe = await repositorio.Existe(id);
            return existe;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(ClaseAsistencia entidad)
        {
            try
            { 
                //ClaseAsistencia entidad = mapper.Map<ClaseAsistencia>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpPut("{id:int}")] //api/ClaseAsistencia/
        public async Task<ActionResult> Put(int id, [FromBody] ClaseAsistencia entidad)
        {
            try
            {

                if (id != entidad.Id)
                {
                    return BadRequest("Datos Incorrectos");
                }
                var d = await repositorio.Update(id, entidad);

                if (!d)
                {
                    return BadRequest("No se pudo actualiza la clase buscada.");
                }
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
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La claseasistencia no se pudo borrar");
            }            return Ok();
        }
    }
}
