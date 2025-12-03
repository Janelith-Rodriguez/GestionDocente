using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class TurnoRepositorio : Repositorio<Turno>, ITurnoRepositorio
    {
        private readonly Context context;

        public TurnoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Turno>> SelectByMateriaPlan(int materiaPlanId)
        {
            return await context.Turnos
                .Include(t => t.MateriaEnPlanEstudio)
                .Include(t => t.Profesor)
                .AsNoTracking()
                .Where(x => x.MateriaEnPlanEstudioId == materiaPlanId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Turno>> SelectByProfesor(int profesorId)
        {
            return await context.Turnos
                .Include(t => t.MateriaEnPlanEstudio)
                .AsNoTracking()
                .Where(x => x.ProfesorId == profesorId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Turno>> SelectByCicloLectivo(int annoCicloLectivo)
        {
            return await context.Turnos
                .Include(t => t.MateriaEnPlanEstudio)
                .AsNoTracking()
                .Where(x => x.AnnoCicloLectivo == annoCicloLectivo && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Turno>> SelectBySede(string sede)
        {
            return await context.Turnos
                .Include(t => t.MateriaEnPlanEstudio)
                .AsNoTracking()
                .Where(x => x.Sede == sede && x.Activo)
                .ToListAsync();
        }
    }
}
