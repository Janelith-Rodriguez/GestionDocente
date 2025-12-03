using AutoMapper;
using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.Shared.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Controllers
{
    [ApiController]
    [Route("api/Clases")]
    public class ClasesControllers : ControllerBase
    {
        private readonly IClaseRepositorio repositorio;
        //private readonly IMapper mapper;

        public ClasesControllers(IClaseRepositorio repositorio)
        {
            this.repositorio = repositorio;
            //this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<Clase>>> Get() 
        {
            return await repositorio.Select();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clase>> Get(int id)
        {
            Clase? d = await repositorio.SelectById(id);
            if (d == null)
            {
                return NotFound();
            }
            return d;
           
        }

        [HttpGet("existe/{id:int}")]
        public async Task<ActionResult<bool>> Existe(int id)
        {
            return await repositorio.Existe(id);
           
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Clase entidad)
        {
            try
            {
                return await repositorio.Insert(entidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }        
        }

        [HttpPut("{id:int}")] //api/Clase/
        public async Task<ActionResult> Put(int id, [FromBody] Clase entidad)
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
                    return BadRequest("No existe la clase buscada.");
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
                return BadRequest("La clase no se pudo borrar");
                
            }
            return Ok();
        }
    }
}
