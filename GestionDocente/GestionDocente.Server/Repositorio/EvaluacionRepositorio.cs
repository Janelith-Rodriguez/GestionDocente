using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class EvaluacionRepositorio : Repositorio<Evaluacion>, IEvaluacionRepositorio
    {
        private readonly Context context;

        public EvaluacionRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Evaluacion>> SelectByTurno(int turnoId)
        {
            return await context.Evaluaciones
                .Include(e => e.Turno)
                .AsNoTracking()
                .Where(x => x.TurnoId == turnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Evaluacion>> SelectByTipo(string tipoEvaluacion)
        {
            return await context.Evaluaciones
                .Include(e => e.Turno)
                .AsNoTracking()
                .Where(x => x.TipoEvaluacion == tipoEvaluacion && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Evaluacion>> SelectByFecha(DateTime fecha)
        {
            return await context.Evaluaciones
                .Include(e => e.Turno)
                .AsNoTracking()
                .Where(x => x.Fecha.Date == fecha.Date && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Evaluacion>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await context.Evaluaciones
                .Include(e => e.Turno)
                .AsNoTracking()
                .Where(x => x.Fecha >= fechaInicio && x.Fecha <= fechaFin && x.Activo)
                .ToListAsync();
        }
    }
}
