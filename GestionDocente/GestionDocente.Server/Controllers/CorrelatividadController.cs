using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Correlatividades")]
    public class CorrelatividadesController : ControllerBase
    {
        private readonly ICorrelatividadRepositorio repositorio;

        public CorrelatividadesController(ICorrelatividadRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]    //api/Correlatividades
        public async Task<ActionResult<List<Correlatividad>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")] //api/Correlatividades/2
        public async Task<ActionResult<Correlatividad>> Get(int id)
        {
            Correlatividad? entidad = await repositorio.SelectById(id);
            if (entidad == null)
            {
                return NotFound();
            }
            return entidad;
        }

        [HttpGet("GetByMateria/{materiaPlanId}")] //api/Correlatividades/GetByMateria/1
        public async Task<ActionResult<List<Correlatividad>>> GetByMateria(int materiaPlanId)
        {
            var entidades = await repositorio.SelectByMateriaPlan(materiaPlanId);
            return entidades;
        }

        [HttpGet("existe/{id:int}")] //api/Correlatividades/existe/2
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Correlatividad entidad)
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

        [HttpPut("{id:int}")] //api/Correlatividades/2
        public async Task<ActionResult> Put(int id, [FromBody] Correlatividad entidad)
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
                    return BadRequest("No se pudo actualizar la correlatividad");
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}")] //api/Correlatividades/2
        public async Task<ActionResult> Delete(int id)
        {
            var resp = await repositorio.Delete(id);
            if (!resp)
            {
                return BadRequest("La correlatividad no se pudo borrar");
            }
            return Ok();
        }
    }
}
