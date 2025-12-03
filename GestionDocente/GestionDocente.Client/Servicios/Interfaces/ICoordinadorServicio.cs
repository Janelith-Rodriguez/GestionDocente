using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICoordinadorServicio : IServicio<Coordinador>
    {
        Task<HttpRespuesta<Coordinador>> GetByUsuario(int usuarioId);
        Task<HttpRespuesta<List<Coordinador>>> GetByCarrera(int carreraId);
        Task<HttpRespuesta<List<Coordinador>>> GetByEstado(bool estado);
    }
}