using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CorrelatividadRepositorio : Repositorio<Correlatividad>, ICorrelatividadRepositorio
    {
        private readonly Context context;

        public CorrelatividadRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Correlatividad>> SelectByMateriaPlan(int materiaPlanId)
        {
            return await context.Correlatividades
                .Include(c => c.MateriaEnPlanEstudio)
                .Include(c => c.MateriaCorrelativa)
                .AsNoTracking()
                .Where(x => x.MateriaEnPlanEstudioId == materiaPlanId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Correlatividad>> SelectByMateriaCorrelativa(int materiaCorrelativaId)
        {
            return await context.Correlatividades
                .Include(c => c.MateriaEnPlanEstudio)
                .AsNoTracking()
                .Where(x => x.MateriaCorrelativaId == materiaCorrelativaId && x.Activo)
                .ToListAsync();
        }
    }
}
