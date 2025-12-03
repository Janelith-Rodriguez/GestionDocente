using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearCUPOF_CoordinadorDTO
    {
        [Required(ErrorMessage = "La carrera es obligatoria")]
        public int CarreraId { get; set; }

        public int? CoordinadorId { get; set; }

        [Required(ErrorMessage = "El código del CUPOF es necesario")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string CUPOF { get; set; }

        [Required(ErrorMessage = "El estado de ocupación es necesario")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Ocupado_Libre { get; set; }

        [Required(ErrorMessage = "El estado del CUPOF es necesario")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La sede es necesaria")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Sede { get; set; }
    }
}
