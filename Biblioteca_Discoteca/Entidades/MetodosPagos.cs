using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class MetodosPagos
    {
        [Key]
        public int IdMetodoPago { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoMetodoPago { get; set; }
        public string? NumeroCuenta { get; set; }

        [ForeignKey("IdCliente")]
        public Clientes? _Cliente { get; set; }

        public List<Facturas>? _Facturas { get; set; }
    }
}
