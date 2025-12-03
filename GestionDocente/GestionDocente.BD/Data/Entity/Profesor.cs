using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class Profesor : EntityBase
    {
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }

        public bool Estado { get; set; } = true;
    }
}
