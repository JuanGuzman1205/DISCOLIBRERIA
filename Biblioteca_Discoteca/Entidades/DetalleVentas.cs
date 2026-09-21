using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleVentas
    {
        [Key]
        public int IdDetalleVenta { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        [ForeignKey("IdVenta")]
        public Ventas? _Venta { get; set; }

        [ForeignKey("IdProducto")]
        public Productos? _Producto { get; set; }
    }
}
