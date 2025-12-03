using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CertificadoAlumnoRepositorio : Repositorio<CertificadoAlumno>, ICertificadoAlumnoRepositorio
    {
        private readonly Context context;

        public CertificadoAlumnoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<CertificadoAlumno>> SelectByNombre(string nombre)
        {
            return await context.CertificadosAlumnos
                .AsNoTracking()
                .Where(x => x.Nombre.Contains(nombre) && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CertificadoAlumno>> SelectByDuracion(string duracion)
        {
            return await context.CertificadosAlumnos
                .AsNoTracking()
                .Where(x => x.DuracionCarrera == duracion && x.Activo)
                .ToListAsync();
        }

        public async Task<List<CertificadoAlumno>> SelectByModalidad(string modalidad)
        {
            return await context.CertificadosAlumnos
                .AsNoTracking()
                .Where(x => x.Modalidad == modalidad && x.Activo)
                .ToListAsync();
        }
    }
}
