using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class MateriaEnPlanEstudioRepositorio : Repositorio<MateriaEnPlanEstudio>, IMateriaEnPlanEstudioRepositorio
    {
        private readonly Context context;

        public MateriaEnPlanEstudioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<MateriaEnPlanEstudio>> SelectByPlanEstudio(int planEstudioId)
        {
            return await context.MateriasEnPlanEstudio
                .Include(m => m.Materia)
                .Include(m => m.PlanEstudio)
                .AsNoTracking()
                .Where(x => x.PlanEstudioId == planEstudioId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<MateriaEnPlanEstudio>> SelectByMateria(int materiaId)
        {
            return await context.MateriasEnPlanEstudio
                .Include(m => m.PlanEstudio)
                .AsNoTracking()
                .Where(x => x.MateriaId == materiaId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<MateriaEnPlanEstudio>> SelectByAnno(int anno)
        {
            return await context.MateriasEnPlanEstudio
                .Include(m => m.Materia)
                .AsNoTracking()
                .Where(x => x.Anno == anno && x.Activo)
                .ToListAsync();
        }
    }
}