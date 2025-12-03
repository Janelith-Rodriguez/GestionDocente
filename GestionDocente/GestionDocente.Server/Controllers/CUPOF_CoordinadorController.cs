using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/CUPOFCoordinadores")]
    public class CUPOFCoordinadoresController : ControllerBase
    {
        private readonly ICUPOF_CoordinadorRepositorio repositorio;

        public CUPOFCoordinadoresController(ICUPOF_CoordinadorRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/CUPOFCoordinadores
        public async Task<ActionResult<List<CUPOF_Coordinador>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/CUPOFCoordinadores/2
        public async Task<ActionResult<CUPOF_Coordinador>> Get(int id)
        {
            CUPOF_Coordinador? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByCarrera/{carreraId}")] //api/CUPOFCoordinadores/GetByCarrera/1
        public async Task<ActionResult<List<CUPOF_Coordinador>>> GetByCarrera(int carreraId)
        {
            var entidades = await repositorio.SelectByCarrera(carreraId);
            return entidades;
        }

        [HttpGet("GetByCoordinador/{coordinadorId}")] //api/CUPOFCoordinadores/GetByCoordinador/1
        public async Task<ActionResult<List<CUPOF_Coordinador>>> GetByCoordinador(int coordinadorId)
        {
            var entidades = await repositorio.SelectByCoordinador(coordinadorId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/CUPOFCoordinadores/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(CUPOF_Coordinador entidad)
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

        [HttpPut("{id:int}")] //api/CUPOFCoordinadores/2
        public async Task<ActionResult> Put(int id, [FromBody] CUPOF_Coordinador entidad)
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
                    return BadRequest("No se pudo actualizar el CUPOF del coordinador");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/CUPOFCoordinadores/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("El CUPOF del coordinador no se pudo borrar");
            }
            return Ok();
        }
    }
}
