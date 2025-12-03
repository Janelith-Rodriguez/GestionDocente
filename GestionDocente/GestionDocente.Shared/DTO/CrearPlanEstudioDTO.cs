using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearPlanEstudioDTO
    {
        [Required(ErrorMessage = "El nombre del plan de estudio es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El año del plan es obligatorio")]
        public int Anno { get; set; }

        [Required(ErrorMessage = "El estado del plan es obligatorio")]
        public bool EstadoPlan { get; set; }

        [Required(ErrorMessage = "La carrera es obligatoria")]
        public int CarreraId { get; set; }
    }
}
