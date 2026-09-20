using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario_Discoteca.Entidades
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public int IdProveedor { get; set; }
        public int IdInventario { get; set; }
        public string? NomProducto { get; set; }
        public string? Presentacion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        public Proveedores? _Proveedor { get; set; }
        public CategoriaProductos? _CategoriaProducto { get; set; }
        public List<DetalleVentas>? _DetalleVentas { get; set; }
        public List<DetalleCompras>? _DetalleCompras { get; set; }
        public Inventarios? _Inventario { get; set; }

    }
}
