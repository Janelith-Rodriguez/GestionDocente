using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CUPOF_ProfesorRepositorio : Repositorio<CUPOF_Profesor>, ICUPOF_ProfesorRepositorio
    {
        private readonly Context context;

        public CUPOF_ProfesorRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<CUPOF_Profesor>> SelectByTurno(int turnoId)
        {
            return await context.CUPOF_Profesores
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.TurnoId == turnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CUPOF_Profesor>> SelectByEstado(bool estado)
        {
            return await context.CUPOF_Profesores
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CUPOF_Profesor>> SelectByOcupadoLibre(string estadoOcupacion)
        {
            return await context.CUPOF_Profesores
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.Ocupado_Libre == estadoOcupacion && x.Activo)
                .ToListAsync();
        }
    }
}
