using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Ventas
    {
        [Key]
        public int IdVenta { get; set; }
        public int IdEmpleado { get; set; }
        public int IdFactura { get; set; }
        public decimal Total { get; set; }
        public bool Estado { get; set; } // True: Mesa abierta , False: Mesa cerrada.

        [ForeignKey("IdEmpleado")]
        public Empleados? _Empleado { get; set; }

        [ForeignKey("IdFactura")]
        public Facturas? _Factura { get; set; }
        public List<DetalleVentas>? _DetalleVentas { get; set; }
    }
}
