using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface ICertificadoAlumnoRepositorio : IRepositorio<CertificadoAlumno>
    {
        Task<List<CertificadoAlumno>> SelectByNombre(string nombre);
        Task<List<CertificadoAlumno>> SelectByDuracion(string duracion);
        Task<List<CertificadoAlumno>> SelectByModalidad(string modalidad);
    }
}