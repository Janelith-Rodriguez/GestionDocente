using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Context context) : base(context)
        {
        }
    }
}
