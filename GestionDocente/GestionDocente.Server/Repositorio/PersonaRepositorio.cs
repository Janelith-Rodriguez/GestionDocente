using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class PersonaRepositorio : Repositorio<Persona>, IPersonaRepositorio
    {
        private readonly Context context;

        public PersonaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<Persona> SelectByDocumento(string documento)
        {
            return await context.Personas
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Documento == documento && x.Activo);
        }

        public async Task<List<Persona>> SelectByTipoDocumento(int tipoDocumentoId)
        {
            return await context.Personas
                .AsNoTracking()
                .Where(x => x.TipoDocumentoId == tipoDocumentoId && x.Activo)
                .ToListAsync();
        }

        public async Task<List<Persona>> SelectByNombreApellido(string nombre, string apellido)
        {
            return await context.Personas
                .AsNoTracking()
                .Where(x => x.Nombre.Contains(nombre) && x.Apellido.Contains(apellido) && x.Activo)
                .ToListAsync();
        }
    }
}
