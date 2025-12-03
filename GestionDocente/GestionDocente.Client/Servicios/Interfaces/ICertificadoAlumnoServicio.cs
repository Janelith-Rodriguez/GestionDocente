using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICertificadoAlumnoServicio : IServicio<CertificadoAlumno>
    {
        Task<HttpRespuesta<List<CertificadoAlumno>>> GetByNombre(string nombre);
        Task<HttpRespuesta<List<CertificadoAlumno>>> GetByDuracion(string duracion);
        Task<HttpRespuesta<List<CertificadoAlumno>>> GetByModalidad(string modalidad);
    }
}
