using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class MovimientoInventarios
    {
        public int IdMovimiento { get; set; }
        public int IdInventario { get; set; }
        public string? TipoMovimiento { get; set; }   // Esto es por si entra o sale algo del inv
        public int Cantidad { get; set; } // Se refiere a la cantidad del movimiento que va salir o antrar
        public DateTime FechaMovimiento { get; set; }

        public Inventarios? _Inventario { get; set; }
    }
}
