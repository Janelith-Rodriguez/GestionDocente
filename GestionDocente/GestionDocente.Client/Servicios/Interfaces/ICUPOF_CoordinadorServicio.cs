using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Client.Servicios
{
    public interface ICUPOF_CoordinadorServicio : IServicio<CUPOF_Coordinador>
    {
        Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByCarrera(int carreraId);
        Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByCoordinador(int coordinadorId);
        Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByEstado(bool estado);
        Task<HttpRespuesta<List<CUPOF_Coordinador>>> GetByOcupadoLibre(string estadoOcupacion);
    }
}
