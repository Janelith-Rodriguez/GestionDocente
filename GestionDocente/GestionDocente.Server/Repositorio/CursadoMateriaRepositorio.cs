using GestionDocente.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;

namespace GestionDocente.Server.Repositorio
{
    public class CursadoMateriaRepositorio : Repositorio<CursadoMateria>, ICursadoMateriaRepositorio
    {
        private readonly Context context;
        public CursadoMateriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
        public async Task<CursadoMateria> FullGetById(int id)
        {
            return await context.CursadosMateria
                .Include(u => u.Alumno)
                .Include(u => u.Turno)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<CursadoMateria>> FullGetAll()
        {
            return await context.CursadosMateria
                .Include(u => u.Alumno)
                .Include(u => u.Turno)
                .ToListAsync();
        }

    }
}







