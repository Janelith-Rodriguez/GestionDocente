using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class MABRepositorio : Repositorio<MAB>, IMABRepositorio
    {
        private readonly Context context;

        public MABRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<MAB>> SelectByProfesor(int profesorId)
        {
            return await context.MAB
                .Include(m => m.Profesor)
                .Include(m => m.CUPOF_Profesor)
                .AsNoTracking()
                .Where(x => x.ProfesorId == profesorId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<MAB>> SelectByCUPOFProfesor(int cupofProfesorId)
        {
            return await context.MAB
                .Include(m => m.Profesor)
                .AsNoTracking()
                .Where(x => x.CUPOF_ProfesorId == cupofProfesorId && x.Activo)
                .ToListAsync();
        }

        public async Task<MAB> SelectByIdMab(string idMab)
        {
            return await context.MAB
                .Include(m => m.Profesor)
                .Include(m => m.CUPOF_Profesor)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.IdMab == idMab && x.Activo);
        }

        public async Task<List<MAB>> SelectBySitRevista(string sitRevista)
        {
            return await context.MAB
                .Include(m => m.Profesor)
                .Include(m => m.CUPOF_Profesor)
                .AsNoTracking()
                .Where(x => x.SitRevista == sitRevista && x.Activo)
                .ToListAsync();
        }

        public async Task<List<MAB>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await context.MAB
                .Include(m => m.Profesor)
                .Include(m => m.CUPOF_Profesor)
                .AsNoTracking()
                .Where(x => x.FechaInicio >= fechaInicio && x.FechaFin <= fechaFin && x.Activo)
                .ToListAsync();
        }
    }
}

