using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Reservas
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public DateTime FechaReserva { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("IdCliente")]
        public Clientes? _Cliente { get; set; }
        public List<DetalleReservas>? _Detalles { get; set; }
    }
}
