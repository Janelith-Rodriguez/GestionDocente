using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICursadoMateriaRepositorio : IRepositorio<CursadoMateria>
    {
        Task<List<CursadoMateria>> SelectByAlumno(int alumnoId);
        Task<List<CursadoMateria>> SelectByTurno(int turnoId);
        Task<List<CursadoMateria>> SelectByCondicion(string condicion);
        Task<List<CursadoMateria>> SelectByAnno(int anno);
    }
}