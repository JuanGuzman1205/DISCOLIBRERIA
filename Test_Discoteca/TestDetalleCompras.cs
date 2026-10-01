using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test_Discoteca
{
    [TestClass]
    public class TestDetalleCompras
    {
        private IConexion conexion;

        // Interfaces de aplicación
        private IDetalleComprasAplicacion servicioDetalleCompras;
        private IComprasAplicacion servicioCompras;
        private IEmpleadosAplicacion servicioEmpleados;
        private IProductosAplicacion servicioProductos;
        private ICategoriaProductosAplicacion servicioCategorias;
        private IProveedoresAplicacion servicioProveedores;
        private IInventariosAplicacion servicioInventarios;

        // Entidades
        private DetalleCompras? entidad = null;
        private Compras? compra = null;
        private Empleados? empleado = null;
        private Productos? producto = null;
        private CategoriaProductos? categoria = null;
        private Proveedores? proveedor = null;
        private Inventarios? inventario = null;

        public TestDetalleCompras()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioDetalleCompras = new DetalleComprasAplicacion(this.conexion);
            this.servicioCompras = new ComprasAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioProductos = new ProductosAplicacion(this.conexion);
            this.servicioCategorias = new CategoriaProductosAplicacion(this.conexion);
            this.servicioProveedores = new ProveedoresAplicacion(this.conexion);
            this.servicioInventarios = new InventariosAplicacion(this.conexion);
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            // 1. Crear dependencias para el Producto
            this.categoria = GeneradorDatosPrueba.ObtenerCategoriaProducto();
            this.categoria = this.servicioCategorias.Insertar(this.categoria);

            this.proveedor = GeneradorDatosPrueba.ObtenerProveedor();
            this.proveedor = this.servicioProveedores.Insertar(this.proveedor);

            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            // Insertar Producto con sus IDs
            this.producto = GeneradorDatosPrueba.ObtenerProducto(this.categoria.IdCategoria, this.proveedor.IdProveedor, this.inventario.IdInventario);
            this.producto = this.servicioProductos.Insertar(this.producto);

            // 2. Crear dependencias para la Compra
            this.empleado = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleado = this.servicioEmpleados.Insertar(this.empleado);

            // Insertar Compra con su ID
            this.compra = GeneradorDatosPrueba.ObtenerCompra(this.empleado.IdEmpleado);
            this.compra = this.servicioCompras.Insertar(this.compra);

            // 3. Crear DetalleCompra
            this.entidad = GeneradorDatosPrueba.ObtenerDetalleCompra(this.compra.IdCompra, this.producto.IdProducto);
            this.entidad = this.servicioDetalleCompras.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<DetalleCompras> lista = this.servicioDetalleCompras.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Cantidad = 15;
            this.entidad.Total = 225000;

            var entry = this.conexion.Entry<DetalleCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.empleado != null) this.servicioEmpleados.Borrar(this.empleado);
            if (this.producto != null) this.servicioProductos.Borrar(this.producto);
            if (this.categoria != null) this.servicioCategorias.Borrar(this.categoria);
            if (this.proveedor != null) this.servicioProveedores.Borrar(this.proveedor);
            if (this.inventario != null) this.servicioInventarios.Borrar(this.inventario);
        }
    }
}