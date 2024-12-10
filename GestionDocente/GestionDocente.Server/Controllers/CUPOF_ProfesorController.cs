using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
using GestionDocente.Shared.DTO;

namespace GestionDocente.Server.Controllers

{
        [ApiController]
        [Route("api/CUPOF_Profesores")]
        public class CUPOF_ProfesoresController : ControllerBase
        {
            private readonly IRepositorio<CUPOF_Profesor> repositorio;
            private readonly IMapper mapper;

            public CUPOF_ProfesoresController(IRepositorio<CUPOF_Profesor> repositorio,
                                      IMapper mapper)
            {

                this.repositorio = repositorio;
                this.mapper = mapper;
            }

           

            [HttpGet]
            public async Task<ActionResult<List<CUPOF_Profesor>>> Get()
            {
                return await repositorio.Select();
            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult<CUPOF_Profesor>> Get(int id)
            {
                CUPOF_Profesor? sel = await repositorio.SelectById(id);
                if (sel == null)
                {
                    return NotFound();
                }
                return sel;
            }

            [HttpGet("existe/{id:int}")]
            public async Task<ActionResult<bool>> Existe(int id)
            {
                var existe = await repositorio.Existe(id);
                return existe;

            }

      
        }

    }


