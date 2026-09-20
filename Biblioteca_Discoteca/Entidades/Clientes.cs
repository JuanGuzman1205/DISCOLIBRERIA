using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        public List<Reservas>? _Reservas { get; set; }
        public List<MetodosPagos>? _MetodosPagos { get; set; }
    }
}
