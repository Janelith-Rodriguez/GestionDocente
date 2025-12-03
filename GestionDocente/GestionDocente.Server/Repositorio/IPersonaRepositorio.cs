using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public interface IPersonaRepositorio : IRepositorio<Persona>
    {
        Task<Persona> SelectByDocumento(string documento);
        Task<List<Persona>> SelectByTipoDocumento(int tipoDocumentoId);
        Task<List<Persona>> SelectByNombreApellido(string nombre, string apellido);
    }
}
