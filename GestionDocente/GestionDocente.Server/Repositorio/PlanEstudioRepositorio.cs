using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class PlanEstudioRepositorio : Repositorio<PlanEstudio>, IPlanEstudioRepositorio
    {
        private readonly Context context;

        public PlanEstudioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<PlanEstudio> SelectByNombre(string nombre)
        {
            return await context.PlanEstudios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nombre == nombre && x.Activo);
        }

        public async Task<List<PlanEstudio>> SelectByCarrera(int carreraId)
        {
            return await context.PlanEstudios
                .AsNoTracking()
                .Where(x => x.CarreraId == carreraId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<PlanEstudio>> SelectByAnno(int anno)
        {
            return await context.PlanEstudios
                .AsNoTracking()
                .Where(x => x.Anno == anno && x.Activo)
                .ToListAsync();
        }
    }
}
