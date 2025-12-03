using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearCarreraDTO
    {
        [Required(ErrorMessage = "Campo nombre es obligatorio")]
        [MaxLength(40, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La duración de la carrera es obligatoria")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string DuracionCarrera { get; set; }

        [Required(ErrorMessage = "La modalidad es obligatoria")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Modalidad { get; set; }
    }
}
