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
    [Route("api/Evaluaciones")] //Evaluaciones
    public class EvaluacionesControllers : ControllerBase
    {
        private readonly IEvaluacionRepositorio repositorio;
        private readonly IMapper mapper;

        public EvaluacionesControllers(IEvaluacionRepositorio repositorio,
                                 IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Evaluacion>>> Get()
        {
            return await repositorio.Select();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Evaluacion>> GetById(int id)
        {
            Evaluacion? d = await repositorio.SelectById(id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearEvaluacionDTO entidadDTO)
        {
            try
            {


                Evaluacion entidad = mapper.Map<Evaluacion>(entidadDTO);

                return await repositorio.Insert(entidad);


            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
                //throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Evaluacion entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }
            var d = await repositorio.SelectById(id);


            if (d == null)
            {
                return NotFound("La evaluacion buscada no existe.");
            }

            d.TurnoId = entidad.TurnoId;
            d.Turno = entidad.Turno;
            d.TipoEvaluacion = entidad.TipoEvaluacion;
            d.Folio = entidad.Folio;
            d.Libro = entidad.Libro;
            d.Sede = entidad.Sede;
            try
            {
                await repositorio.Update(id, d);

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
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La evaluacion {id} no existe.");
            }

            if (await repositorio.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}