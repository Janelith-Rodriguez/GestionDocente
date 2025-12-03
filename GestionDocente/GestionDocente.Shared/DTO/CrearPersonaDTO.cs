using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearPersonaDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(80, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(80, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El Número de Documento es obligatorio")]
        [MaxLength(16, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Documento { get; set; }

        [MaxLength(18, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Telefono { get; set; }

        [MaxLength(60, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string? Domicilio { get; set; }

        [Required(ErrorMessage = "El tipo de documento es obligatorio")]
        public int TipoDocumentoId { get; set; }
    }
}
