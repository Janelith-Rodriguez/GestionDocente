using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearTipoDocumentoDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(70, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [MaxLength(6, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Codigo { get; set; }
    }
}
