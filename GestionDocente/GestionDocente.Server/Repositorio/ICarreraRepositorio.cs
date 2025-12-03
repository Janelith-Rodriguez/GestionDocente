using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICarreraRepositorio : IRepositorio<Carrera>
    {
        Task<Carrera> SelectByNombre(string nombre);
    }
}