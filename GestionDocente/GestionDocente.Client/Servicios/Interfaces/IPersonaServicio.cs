using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IPersonaServicio : IServicio<Persona>
    {
        Task<HttpRespuesta<Persona>> GetByDocumento(string documento);
        Task<HttpRespuesta<List<Persona>>> GetByTipoDocumento(int tipoDocumentoId);
        Task<HttpRespuesta<List<Persona>>> GetByNombreApellido(string nombre, string apellido);
    }
}