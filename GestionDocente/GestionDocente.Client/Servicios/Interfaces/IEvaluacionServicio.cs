using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface IEvaluacionServicio : IServicio<Evaluacion>
    {
        Task<HttpRespuesta<List<Evaluacion>>> GetByTurno(int turnoId);
        Task<HttpRespuesta<List<Evaluacion>>> GetByTipo(string tipoEvaluacion);
        Task<HttpRespuesta<List<Evaluacion>>> GetByFecha(DateTime fecha);
        Task<HttpRespuesta<List<Evaluacion>>> GetByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}
