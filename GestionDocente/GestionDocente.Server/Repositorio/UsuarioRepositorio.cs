using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        private readonly Context context;

        public UsuarioRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Usuario> SelectByEmail(string email)
        {
            return await context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email && x.Activo);
        }

        public async Task<Usuario> SelectByPersona(int personaId)
        {
            return await context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PersonaId == personaId && x.Activo);
        }

        public async Task<List<Usuario>> SelectByEstado(bool estado)
        {
            return await context.Usuarios
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }
    }
}