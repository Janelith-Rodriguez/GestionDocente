using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ITipoDocumentoServicio : IServicio<TipoDocumento>
    {
        Task<HttpRespuesta<TipoDocumento>> GetByCodigo(string codigo);
    }
}
