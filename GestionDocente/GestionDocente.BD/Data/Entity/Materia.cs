﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDocente.BD.Data.Entity
{
    [Index(nameof(Nombre), nameof(ResolucionMinisterial), Name = "Materia_UQ", IsUnique = true)]
    [Index(nameof(Nombre), Name = "MateriasPorNombreIDX", IsUnique = false)]
    public class Materia : EntityBase
    {
        [Required(ErrorMessage = "El nombre de la materia es obligatorio")]
        [MaxLength(36, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El formato de la materia es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Formato { get; set; }

        [Required(ErrorMessage = "La formación de la materia es obligatorio")]
        [MaxLength(20, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string Formacion { get; set; }

        [Required(ErrorMessage = "La resolución ministerial de la materia es obligatorio")]
        [MaxLength(36, ErrorMessage = "Máximo número de caracteres {1}.")]
        public string ResolucionMinisterial { get; set; }

        [Required(ErrorMessage = "El año de la materia es obligatorio")]
        public int Anno { get; set; }
    }
}