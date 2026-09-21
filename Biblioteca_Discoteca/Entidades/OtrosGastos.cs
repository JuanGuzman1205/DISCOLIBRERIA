using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class OtrosGastos
    {
        [Key]
        public int IdGasto { get; set; }
        public int IdEmpleado { get; set; }
        public string? Descripcion { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaGasto { get; set; }

        [ForeignKey("IdEmpleado")]
        public Empleados? _Empleado { get; set; }
    }
}
