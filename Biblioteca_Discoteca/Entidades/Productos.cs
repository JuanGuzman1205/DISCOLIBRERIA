using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdInventario { get; set; }
        public string? NomProducto { get; set; }
        public string? Presentacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int stock { get; set; }

        [ForeignKey("IdProveedor")]
        public Proveedores? _Proveedor { get; set; }

        [ForeignKey("IdCategoria")]
        public CategoriaProductos? _CategoriaProducto { get; set; }
        public List<DetalleVentas>? _DetalleVentas { get; set; }
        public List<DetalleCompras>? _DetalleCompras { get; set; }

        [ForeignKey("IdInventario")]
        public Inventarios? _Inventario { get; set; }

    }
}
