using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Proveedores
    {
        [Key]
        public int IdProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        public List<Productos>? _Productos { get; set; }
    }
}
