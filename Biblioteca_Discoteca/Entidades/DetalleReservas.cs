using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleReservas
    {
        public int IdDetalleReserva { get; set; }
        public int IdReserva { get; set; }
        public int IdMesa { get; set; }

        public Reservas? _Reserva { get; set; }
        public Mesas? _Mesa { get; set; }
    }
}
