using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{

    public class ClaseRepositorio : Repositorio<Clase>, IClaseRepositorio 
    {
        private readonly Context context;

        public ClaseRepositorio(Context context): base(context)
        {
            this.context = context;
        }

        public async Task<List<Clase>> SelectByTurno(int turnoId)
        {
            return await context.Clases
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.TurnoId == turnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Clase>> SelectByFecha(DateTime fecha)
        {
            return await context.Clases
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.Fecha.Date == fecha.Date && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Clase>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return await context.Clases
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.Fecha >= fechaInicio && x.Fecha <= fechaFin && x.Activo)
                .ToListAsync();
        }
    }
}
