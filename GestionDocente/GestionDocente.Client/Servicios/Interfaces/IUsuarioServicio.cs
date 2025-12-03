using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IUsuarioServicio : IServicio<Usuario>
    {
        Task<HttpRespuesta<Usuario>> GetByEmail(string email);
        Task<HttpRespuesta<Usuario>> GetByPersona(int personaId);
        Task<HttpRespuesta<List<Usuario>>> GetByEstado(bool estado);
    }
}
