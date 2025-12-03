using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class ClaseAsistenciaRepositorio : Repositorio<ClaseAsistencia>, IClaseAsistenciaRepositorio
    {
        private readonly Context context;

        public ClaseAsistenciaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<ClaseAsistencia>> SelectByClase(int claseId)
        {
            return await context.ClasesAsistencias
                .Include(c => c.Clase)
                .Include(c => c.CursadoMateria)
                .AsNoTracking()
                .Where(x => x.ClaseId == claseId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<ClaseAsistencia>> SelectByCursadoMateria(int cursadoMateriaId)
        {
            return await context.ClasesAsistencias
                .Include(c => c.Clase)
                .AsNoTracking()
                .Where(x => x.CursadoMateriaId == cursadoMateriaId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<ClaseAsistencia>> SelectByAsistencia(char asistencia)
        {
            return await context.ClasesAsistencias
                .Include(c => c.Clase)
                .Include(c => c.CursadoMateria)
                .AsNoTracking()
                .Where(x => x.Asistencia == asistencia && x.Activo)
                .ToListAsync();
        }
    }
}