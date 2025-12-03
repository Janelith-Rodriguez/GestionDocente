using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICursadoMateriaServicio : IServicio<CursadoMateria>
    {
        Task<HttpRespuesta<List<CursadoMateria>>> GetByAlumno(int alumnoId);
        Task<HttpRespuesta<List<CursadoMateria>>> GetByTurno(int turnoId);
        Task<HttpRespuesta<List<CursadoMateria>>> GetByCondicion(string condicion);
        Task<HttpRespuesta<List<CursadoMateria>>> GetByAnno(int anno);
    }
}
