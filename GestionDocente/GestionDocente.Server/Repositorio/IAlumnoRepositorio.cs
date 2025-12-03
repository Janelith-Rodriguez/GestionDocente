using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IAlumnoRepositorio : IRepositorio<Alumno>
    {
        Task<Alumno> SelectByUsuario(int usuarioId);
        Task<List<Alumno>> SelectByEstado(bool estado);
        Task<List<Alumno>> SelectByPais(string pais);
    }
}