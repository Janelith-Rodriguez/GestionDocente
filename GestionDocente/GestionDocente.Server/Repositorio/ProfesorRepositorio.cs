using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class ProfesorRepositorio : Repositorio<Profesor>, IProfesorRepositorio
    {
        private readonly Context context;

        public ProfesorRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Profesor> SelectByUsuario(int usuarioId)
        {
            return await context.Profesores
                .Include(p => p.Usuario)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.Activo);
        }

        public async Task<List<Profesor>> SelectByEstado(bool estado)
        {
            return await context.Profesores
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }
    }
}
