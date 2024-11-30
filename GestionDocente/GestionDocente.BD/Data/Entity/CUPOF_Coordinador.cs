using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class CUPOF_Coordinador : EntityBase
    {
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }

        public int? CoordinadorId { get; set; }
        public Coordinador? Coordinador { get; set; }

        [Required(ErrorMessage = "El codigo del CUPOF (CUPOF en sí) es necesario")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CUPOF { get; set; }

        [Required(ErrorMessage = "Saber si el puesto está ocupado o libre es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Ocupado_Libre { get; set; }

        [Required(ErrorMessage = "El estado del CUPOF es necesario")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La sede es necesaria")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sede { get; set; }
    }
}
