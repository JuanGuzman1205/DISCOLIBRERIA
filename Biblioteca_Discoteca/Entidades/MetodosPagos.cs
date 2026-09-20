using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class MetodosPagos
    {
        public int IdMetodoPago { get; set; }
        public int? IdCliente { get; set; }
        public string? TipoMetodoPago { get; set; }
        public string? NumeroCuenta { get; set; }

        public Clientes? _Cliente { get; set; }

        public List<Facturas>? _Facturas { get; set; }
    }
}
