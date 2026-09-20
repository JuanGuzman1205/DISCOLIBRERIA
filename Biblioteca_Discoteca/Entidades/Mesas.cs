using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Mesas
    {
        public int IdMesa { get; set; }
        public int ConsumoMinimo { get; set; }
        public string? Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public List<DetalleReservas>? _DetalleReservas { get; set; }
    }
}
