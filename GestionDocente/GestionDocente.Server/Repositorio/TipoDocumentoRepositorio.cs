using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace GestionDocente.Server.Repositorio
{
    public class TipoDocumentoRepositorio : Repositorio<TipoDocumento>, ITipoDocumentoRepositorio
    {
        private readonly Context context;

        public TipoDocumentoRepositorio(Context context) : base(context)
        {
            this.context = context;
        }

        public async Task<TipoDocumento> SelectByCod(string codigo)
        {
            return await context.TipoDocumentos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Codigo == codigo && x.Activo);
        }
    }
}
