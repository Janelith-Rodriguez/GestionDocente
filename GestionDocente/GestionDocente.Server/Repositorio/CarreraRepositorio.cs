using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class CarreraRepositorio : Repositorio<Carrera>, ICarreraRepositorio
    {
        private readonly Context context;

        public CarreraRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Carrera> SelectByNombre(string nombre)
        {
            return await context.Carreras
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nombre == nombre && x.Activo);
        }
    }
}