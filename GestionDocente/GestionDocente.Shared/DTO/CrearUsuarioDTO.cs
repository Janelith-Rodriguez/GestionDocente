using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.Shared.DTO
{
    public class CrearUsuarioDTO
    {
        [Required(ErrorMessage = "Ingrese el correo electrónico")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "La persona es obligatoria")]
        public int PersonaId { get; set; }
    }
}
