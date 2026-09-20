using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Compras
    {
        public int IdCompra { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }

        public Empleados? _Empleado { get; set; }
        public List<DetalleCompras>? _DetalleCompras { get; set; }
    }
}
