using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Reparaciones
    {
        [Key]
        public int IdReparacion { get; set; }
        public int IdSolicitante { get; set; }
        public int IdEncargado { get; set; }
        public DateTime FechaReparacion { get; set; }

        [ForeignKey("IdSolicitante")]
        public Empleados? _Solicitante { get; set; }

        [ForeignKey("IdEncargado")]
        public Empleados? _Encargado { get; set; }

        public List<DetalleReparaciones>? _DetalleReparaciones { get; set; }
    }
}
