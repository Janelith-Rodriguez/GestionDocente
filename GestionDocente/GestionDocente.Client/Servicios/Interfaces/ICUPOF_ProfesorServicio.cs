using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICUPOF_ProfesorServicio : IServicio<CUPOF_Profesor>
    {
        Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByTurno(int turnoId);
        Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByEstado(bool estado);
        Task<HttpRespuesta<List<CUPOF_Profesor>>> GetByOcupadoLibre(string estadoOcupacion);
    }
}