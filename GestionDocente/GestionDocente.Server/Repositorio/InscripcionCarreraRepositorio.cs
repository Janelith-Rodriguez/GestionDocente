using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class InscripcionCarreraRepositorio : Repositorio<InscripcionCarrera>, IInscripcionCarreraRepositorio
    {
        private readonly Context context;

        public InscripcionCarreraRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<InscripcionCarrera>> SelectByAlumno(int alumnoId)
        {
            return await context.InscripcionCarreras
                .Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .AsNoTracking()
                .Where(x => x.AlumnoId == alumnoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<InscripcionCarrera>> SelectByCarrera(int carreraId)
        {
            return await context.InscripcionCarreras
                .Include(i => i.Alumno)
                .AsNoTracking()
                .Where(x => x.CarreraId == carreraId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<InscripcionCarrera>> SelectByCohorte(int cohorte)
        {
            return await context.InscripcionCarreras
                .Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .AsNoTracking()
                .Where(x => x.Cohorte == cohorte && x.Activo)
                .ToListAsync();
        }

        public async Task<InscripcionCarrera> SelectByLegajo(string legajo)
        {
            return await context.InscripcionCarreras
                .Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Legajo == legajo && x.Activo);
        }
    }
}