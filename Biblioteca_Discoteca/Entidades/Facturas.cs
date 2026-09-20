using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Facturas
    {
        public int IdFactura { get; set; }
        public int IdVenta { get; set; }
        public int IdMesero { get; set; }
        public int IdBarra { get; set; }
        public int IdCaja { get; set; }
        public int IdMetodoPago { get; set; }
        public DateTime FechaFacturacion { get; set; }

        public Ventas? _Venta { get; set; }
        public Empleados? _Mesero { get; set; }
        public Empleados? _Barra { get; set; }
        public Cajas? _Caja { get; set; }
        public MetodosPagos? _MetodoPago { get; set; }
    }
}
