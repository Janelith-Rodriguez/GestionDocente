using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    public class Usuario : EntityBase
    {
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        [Required(ErrorMessage = "Ingrese el correo electrónico")]
        [MaxLength(100, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese la contraseña")]
        [MaxLength(30, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Contrasena { get; set; }

        public bool Estado { get; set; }
    }
}
