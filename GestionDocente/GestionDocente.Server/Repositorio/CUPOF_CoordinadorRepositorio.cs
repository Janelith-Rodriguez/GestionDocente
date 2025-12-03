using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CUPOF_CoordinadorRepositorio : Repositorio<CUPOF_Coordinador>, ICUPOF_CoordinadorRepositorio
    {
        private readonly Context context;

        public CUPOF_CoordinadorRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<CUPOF_Coordinador>> SelectByCarrera(int carreraId)
        {
            return await context.CUPOF_Coordinadores
                .Include(c => c.Carrera)
                .Include(c => c.Coordinador)
                .AsNoTracking()
                .Where(x => x.CarreraId == carreraId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CUPOF_Coordinador>> SelectByCoordinador(int coordinadorId)
        {
            return await context.CUPOF_Coordinadores
                .Include(c => c.Carrera)
                .AsNoTracking()
                .Where(x => x.CoordinadorId == coordinadorId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CUPOF_Coordinador>> SelectByEstado(bool estado)
        {
            return await context.CUPOF_Coordinadores
                .Include(c => c.Carrera)
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CUPOF_Coordinador>> SelectByOcupadoLibre(string estadoOcupacion)
        {
            return await context.CUPOF_Coordinadores
                .Include(c => c.Carrera)
                .Include(c => c.Coordinador)
                .AsNoTracking()
                .Where(x => x.Ocupado_Libre == estadoOcupacion && x.Activo)
                .ToListAsync();
        }
    }
}
