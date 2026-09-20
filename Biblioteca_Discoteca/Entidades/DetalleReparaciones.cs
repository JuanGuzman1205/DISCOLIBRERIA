using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleReparaciones
    {
        public int IdDetalleReparacion { get; set; }
        public int IdReparacion { get; set; }
        public int IdElementoInterno { get; set; }
        public string? DescripcionReparacion { get; set; }
        public decimal CostoReparacion { get; set; }

        public ElementosInternos? _ElementoInterno { get; set; }
        public Reparaciones? _Reparacion { get; set; }
    }
}
