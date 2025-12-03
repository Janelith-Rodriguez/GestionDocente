using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CoordinadorRepositorio : Repositorio<Coordinador>, ICoordinadorRepositorio
    {
        private readonly Context context;

        public CoordinadorRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Coordinador> SelectByUsuario(int usuarioId)
        {
            return await context.Coordinadores
                .Include(c => c.Usuario)
                .Include(c => c.Carrera)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.Activo);
        }

        public async Task<List<Coordinador>> SelectByCarrera(int carreraId)
        {
            return await context.Coordinadores
                .Include(c => c.Usuario)
                .AsNoTracking()
                .Where(x => x.CarreraId == carreraId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Coordinador>> SelectByEstado(bool estado)
        {
            return await context.Coordinadores
                .AsNoTracking()
                .Where(x => x.Estado == estado && x.Activo)
                .ToListAsync();
        }
    }
}