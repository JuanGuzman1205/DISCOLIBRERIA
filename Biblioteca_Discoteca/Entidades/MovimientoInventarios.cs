using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class MovimientoInventarios
    {
        [Key]
        public int IdMovimiento { get; set; }
        public int IdInventario { get; set; }
        public string? TipoMovimiento { get; set; }   // Esto es por si entra o sale algo del inv
        public int Cantidad { get; set; } // Se refiere a la cantidad del movimiento que va salir o antrar
        public DateTime FechaMovimiento { get; set; }

        [ForeignKey("IdInventario")]
        public Inventarios? _Inventario { get; set; }
    }
}
