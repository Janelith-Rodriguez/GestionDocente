using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class CUPOF_Profesor : EntityBase
    {
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

        [Required(ErrorMessage = "El codigo del CUPOF (CUPOF en sí) es obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CUPOF { get; set; }

        [Required(ErrorMessage = "Saber si el CUPOF está ocpuado o libre es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Ocupado_Libre { get; set; }

        [Required(ErrorMessage = "El estado del CUPOF es obligatorio")]
        public bool Estado { get; set; }
    }
}
