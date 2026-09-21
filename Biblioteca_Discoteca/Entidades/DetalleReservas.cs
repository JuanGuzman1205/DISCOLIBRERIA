using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleReservas
    {
        [Key]
        public int IdDetalleReserva { get; set; }
        public int IdReserva { get; set; }
        public int IdMesa { get; set; }

        [ForeignKey("IdReserva")]
        public Reservas? _Reserva { get; set; }

        [ForeignKey("IdMesa")]
        public Mesas? _Mesa { get; set; }
        
    }
}
