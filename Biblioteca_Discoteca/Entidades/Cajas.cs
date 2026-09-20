using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Cajas
    {
        public int IdCaja { get; set; }
        public int IdEmpleadoCaja { get; set; } // Es quien Abre y cierra la caja
        public decimal DineroInicial { get; set; }
        public decimal DineroFinal { get; set; }
        public decimal Ganancias { get; set; }

        public Empleados? _EmpleadoCaja { get; set; }
        public List<Facturas>? _HistorialFacturas { get; set; }
    }
}
