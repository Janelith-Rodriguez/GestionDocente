using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class ProfesorRepositorio : Repositorio<Profesor>, IProfesorRepositorio
    {
        public ProfesorRepositorio(Context context) : base(context)
        {
        }
    }
}
