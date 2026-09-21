using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Empleados
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Telefono { get; set; }
        public string? Cargo { get; set; }
        public decimal Nomina { get; set; }

        public List<Ventas>? _Ventas { get; set; }

        [InverseProperty("_Solicitante")]
        public List<Reparaciones>? _ReparacionesComoSolicitante { get; set; }

        [InverseProperty("_Encargado")]
        public List<Reparaciones>? _ReparacionesComoEncargado { get; set; }
        public List<Eventos>? _Eventos { get; set; }

        [InverseProperty("_Mesero")]
        public List<Facturas>? _FacturasComoMesero { get; set; }

        [InverseProperty("_Barra")]
        public List<Facturas>? _FacturasComoBarra { get; set; }
        public List<Cajas>? _CajasResponsable { get; set; }
        public List<Compras>? _Compras { get; set; }
        public List<OtrosGastos>? _OtrosGastos { get; set; }
    }
}
