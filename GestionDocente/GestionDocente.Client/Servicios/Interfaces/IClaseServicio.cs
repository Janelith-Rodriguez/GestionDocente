using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IClaseServicio : IServicio<Clase>
    {
        Task<HttpRespuesta<List<Clase>>> GetByTurno(int turnoId);
        Task<HttpRespuesta<List<Clase>>> GetByFecha(DateTime fecha);
        Task<HttpRespuesta<List<Clase>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}