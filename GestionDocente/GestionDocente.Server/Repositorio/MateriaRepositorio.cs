using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class MateriaRepositorio : Repositorio<Materia>, IMateriaRepositorio
    {
        private readonly Context context;

        public MateriaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Materia> SelectByNombre(string nombre)
        {
            return await context.Materias
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nombre == nombre && x.Activo);
        }

        public async Task<List<Materia>> SelectByFormacion(string formacion)
        {
            return await context.Materias
                .AsNoTracking()
                .Where(x => x.Formacion == formacion && x.Activo)
                .ToListAsync();
        }
    }
}
