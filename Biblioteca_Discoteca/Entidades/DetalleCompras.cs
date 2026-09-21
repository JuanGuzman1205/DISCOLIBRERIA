using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class DetalleCompras
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("IdCompra")]
        public Compras? _Compra { get; set; }

        [ForeignKey("IdProducto")]
        public Productos? _Producto { get; set; }
        

    }
}
