using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class AlumnoRepositorio : Repositorio<Alumno>, IAlumnoRepositorio
    {
        private readonly Context context;

        public AlumnoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Alumno> SelectByUsuario(int usuarioId)
        {
            return await context.Alumnos
                .Include(a => a.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.Activo);
        }

        public async Task<List<Alumno>> SelectByEstado(bool estado)
        {
            return await context.Alumnos
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Alumno>> SelectByPais(string pais)
        {
            return await context.Alumnos
                .AsNoTracking()
                .Where(x => x.Pais == pais && x.Activo)
                .ToListAsync();
        }
    }
}
