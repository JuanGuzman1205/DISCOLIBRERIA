using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class ElementosInternos
    {
        [Key]
        public int IdElementoInterno { get; set; }
        public int IdInventario { get; set; }
        public string? NombreElementoInterno { get; set; }
        public int CantidadElementoInterno { get; set; } // va de la mano con el Inventario
        public decimal PrecioElementoInterno { get; set; }

        public List<DetalleReparaciones>? _DetalleReparaciones { get; set; }

        [ForeignKey("IdInventario")]
        public Inventarios? _Inventario { get; set; }
    }
}
