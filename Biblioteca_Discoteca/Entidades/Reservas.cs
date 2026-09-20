using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Reservas
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public decimal Total { get; set; }

        public Clientes? _Cliente { get; set; }
        public List<DetalleReservas>? _Detalles { get; set; }
    }
}
