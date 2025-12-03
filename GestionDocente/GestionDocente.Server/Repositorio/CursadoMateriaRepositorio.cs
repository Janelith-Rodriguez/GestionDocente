using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CursadoMateriaRepositorio : Repositorio<CursadoMateria>, ICursadoMateriaRepositorio
    {
        private readonly Context context;

        public CursadoMateriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<CursadoMateria>> SelectByAlumno(int alumnoId)
        {
            return await context.CursadosMateria
                .Include(c => c.Alumno)
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.AlumnoId == alumnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CursadoMateria>> SelectByTurno(int turnoId)
        {
            return await context.CursadosMateria
                .Include(c => c.Alumno)
                .AsNoTracking()
                .Where(x => x.TurnoId == turnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CursadoMateria>> SelectByCondicion(string condicion)
        {
            return await context.CursadosMateria
                .Include(c => c.Alumno)
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.CondicionActual == condicion && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CursadoMateria>> SelectByAnno(int anno)
        {
            return await context.CursadosMateria
                .Include(c => c.Alumno)
                .Include(c => c.Turno)
                .AsNoTracking()
                .Where(x => x.Anno == anno && x.Activo)
                .ToListAsync();
        }
    }
}







