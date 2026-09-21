using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdVenta { get; set; }
        public int IdMesero { get; set; }
        public int IdBarra { get; set; }
        public int IdCaja { get; set; }
        public int IdMetodoPago { get; set; }
        public DateTime FechaFacturacion { get; set; }

        [ForeignKey("IdVenta")]
        public Ventas? _Venta { get; set; }

        [ForeignKey("IdMesero")]
        public Empleados? _Mesero { get; set; }

        [ForeignKey("IdBarra")]
        public Empleados? _Barra { get; set; }

        [ForeignKey("IdCaja")]
        public Cajas? _Caja { get; set; }

        [ForeignKey("IdMetodoPago")]
        public MetodosPagos? _MetodoPago { get; set; }
    }
}
