using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICoordinadorRepositorio : IRepositorio<Coordinador>
    {
        Task<Coordinador> SelectByUsuario(int usuarioId);
        Task<List<Coordinador>> SelectByCarrera(int carreraId);
        Task<List<Coordinador>> SelectByEstado(bool estado);
    }
}
