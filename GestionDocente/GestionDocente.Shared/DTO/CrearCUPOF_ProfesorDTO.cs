using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearCUPOF_ProfesorDTO
    {
        [Required(ErrorMessage = "El turno es obligatorio")]
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "El código del CUPOF es obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CUPOF { get; set; }

        [Required(ErrorMessage = "El estado de ocupación es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Ocupado_Libre { get; set; }

        [Required(ErrorMessage = "El estado del CUPOF es obligatorio")]
        public bool Estado { get; set; }
    }
}
