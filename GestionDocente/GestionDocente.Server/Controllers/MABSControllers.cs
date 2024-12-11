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
    [Route("api/MABS")]
    public class MABSControllers : ControllerBase
    {
        private readonly IMABRepositorio repositorio;
        private readonly IMapper mapper;

        public MABSControllers(IMABRepositorio repositorio,
                                     IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }



        [HttpGet]  //api/MABS
        public async Task<ActionResult<List<MAB>>> Get()
        {
            return await repositorio.Select();
            //return await context.MABS.ToListAsync();
        }
    }
}