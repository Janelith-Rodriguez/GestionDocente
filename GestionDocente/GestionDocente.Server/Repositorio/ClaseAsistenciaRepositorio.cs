using GestionDocente.BD.Data;
using GestionDocente.BD.Data.Entity;

namespace GestionDocente.Server.Repositorio
{
    public class ClaseAsistenciaRepositorio : Repositorio<ClaseAsistencia>, IClaseAsistenciaRepositorio
    {
        private readonly Context context;

        public ClaseAsistenciaRepositorio(Context context) : base(context)
        {
            this.context = context;
        }
    }
}
