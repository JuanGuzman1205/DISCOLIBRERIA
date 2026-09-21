using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Cajas
    {
        [Key]
        public int IdCaja { get; set; }
        public int IdEmpleadoCaja { get; set; } // Es quien Abre y cierra la caja
        public decimal DineroInicial { get; set; }
        public decimal DineroFinal { get; set; }
        public decimal Ganancias { get; set; }

        [ForeignKey("IdEmpleadoCaja")]
        public Empleados? _EmpleadoCaja { get; set; }
        
        public List<Facturas>? _HistorialFacturas { get; set; }
    }
}
