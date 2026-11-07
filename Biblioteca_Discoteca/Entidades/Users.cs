using Inventario_Discoteca.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Biblioteca_Discoteca.Entidades
{
    public class Users
    {
        public class Usuario
        {
            [Key]
            public int IdUsuario { get; set; }

            [Required]
            public int IdEmpleado { get; set; }

            [Required]
            [StringLength(50)]
            public string NombreUsuario { get; set; } = null!;

            [Required]
            [StringLength(255)]
            public string Contrasena { get; set; } = null!;

            [Required]
            [StringLength(20)]
            public string Rol { get; set; } = null!;

            public bool Estado { get; set; } = true;

            public DateTime FechaCreacion { get; set; } = DateTime.Now;

            // Propiedad de navegación hacia Empleado
            [ForeignKey("IdEmpleado")]
            public Empleados Empleado { get; set; } = null!;
        }
    }
}
