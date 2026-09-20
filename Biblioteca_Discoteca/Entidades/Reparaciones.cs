using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Reparaciones
    {
        public int IdReparacion { get; set; }
        public int IdSolicitante { get; set; }
        public int IdEncargado { get; set; }
        public DateTime FechaReparacion { get; set; }

        public Empleados? _Solicitante { get; set; }
        public Empleados? _Encargado { get; set; }

        public List<DetalleReparaciones>? _DetalleReparaciones { get; set; }
    }
}
