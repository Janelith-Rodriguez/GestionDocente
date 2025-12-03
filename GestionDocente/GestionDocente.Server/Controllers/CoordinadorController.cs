using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Coordinadores")]
    public class CoordinadoresController : ControllerBase
    {
        private readonly ICoordinadorRepositorio repositorio;

        public CoordinadoresController(ICoordinadorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Coordinadores
        public async Task<ActionResult<List<Coordinador>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Coordinadores/2
        public async Task<ActionResult<Coordinador>> Get(int id)
        {
            Coordinador? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByCarrera/{carreraId}")] //api/Coordinadores/GetByCarrera/1
        public async Task<ActionResult<List<Coordinador>>> GetByCarrera(int carreraId)
        {
            var entidades = await repositorio.SelectByCarrera(carreraId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Coordinadores/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Coordinador entidad)
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

        [HttpPut("{id:int}")] //api/Coordinadores/2
        public async Task<ActionResult> Put(int id, [FromBody] Coordinador entidad)
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
                    return BadRequest("No se pudo actualizar el coordinador");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Coordinadores/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El coordinador no se pudo borrar");
            }
            return Ok();
        }
    }
}
