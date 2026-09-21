using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleReparaciones
    {
        [Key]
        public int IdDetalleReparacion { get; set; }
        public int IdReparacion { get; set; }
        public int IdElementoInterno { get; set; }
        public string? DescripcionReparacion { get; set; }
        public decimal CostoReparacion { get; set; }

        [ForeignKey("IdElementoInterno")]
        public ElementosInternos? _ElementoInterno { get; set; }

        [ForeignKey("IdReparacion")]
        public Reparaciones? _Reparacion { get; set; }
        
    }
}
