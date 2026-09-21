using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class CategoriaProductos
    {
        [Key]
        public int IdCategoria { get; set; }
        public string? NomCategoria { get; set; }

        public List<Productos>? _Productos { get; set; }
    }
}
