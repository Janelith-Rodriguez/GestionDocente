using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ITipoDocumentoRepositorio : IRepositorio<TipoDocumento>
    {
        Task<TipoDocumento> SelectByCod(string codigo);
    }
}
