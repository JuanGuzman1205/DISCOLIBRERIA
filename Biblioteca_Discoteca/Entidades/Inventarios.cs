using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Inventarios
    {
        public int IdInventario { get; set; }
        public int? IdProducto { get; set; }
        public int? IdElementoInterno { get; set; }
        public int Stock { get; set; }

        public Productos? _Producto { get; set; }
        public List<ElementosInternos>? _ElementoInternos { get; set; }
        public List<MovimientoInventarios>? _MovimientoInventarios { get; set; }
    }
}
