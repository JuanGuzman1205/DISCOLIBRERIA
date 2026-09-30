using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Inventarios
    {
        [Key]
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? IdElementoInterno { get; set; }
        public int Stock { get; set; }

        [ForeignKey("IdProducto")]
        public Productos? _Producto { get; set; }
        [ForeignKey("IdElementoInterno")]
        public List<ElementosInternos>? _ElementoInternos { get; set; }
        public List<MovimientoInventarios>? _MovimientoInventarios { get; set; }
    }
}
