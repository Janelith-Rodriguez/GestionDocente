using GestionDocente.BD.Data;
using Microsoft.EntityFrameworkCore;
using GestionDocente.BD.Data.Entity;
using GestionDocente.Server.Repositorio;
namespace GestionDocente.Server.Repositorio
{
    public class CUPOFProfesorRepositorio : Repositorio<CUPOF_Profesor>, ICUPOFProfesorRepositorio
    {
        public CUPOFProfesorRepositorio(Context context) : base(context)
        {
        }
    }
}
