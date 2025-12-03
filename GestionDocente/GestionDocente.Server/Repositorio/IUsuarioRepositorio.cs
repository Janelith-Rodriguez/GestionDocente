using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorio<Usuario>
    {
        Task<Usuario> SelectByEmail(string email);
        Task<Usuario> SelectByPersona(int personaId);
        Task<List<Usuario>> SelectByEstado(bool estado);
    }
}
