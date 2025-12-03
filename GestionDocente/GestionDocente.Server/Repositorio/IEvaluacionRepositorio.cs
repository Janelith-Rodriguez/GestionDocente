using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IEvaluacionRepositorio : IRepositorio<Evaluacion>
    {
        Task<List<Evaluacion>> SelectByTurno(int turnoId);
        Task<List<Evaluacion>> SelectByTipo(string tipoEvaluacion);
        Task<List<Evaluacion>> SelectByFecha(DateTime fecha);
        Task<List<Evaluacion>> SelectByRangoFechas(DateTime fechaInicio, DateTime fechaFin);
    }
}