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
    public class TestDetalleVentas
    {
        private IConexion conexion;
        private IDetalleVentasAplicacion servicioDetalleVentas;
        private IVentasAplicacion servicioVentas;
        private IProductosAplicacion servicioProductos;
        private IEmpleadosAplicacion servicioEmpleados;
        private ICategoriaProductosAplicacion servicioCategorias;
        private IProveedoresAplicacion servicioProveedores;
        private IInventariosAplicacion servicioInventarios;

        private DetalleVentas? entidad = null;
        private Ventas? venta = null;
        private Productos? producto = null;
        private Empleados? empleado = null;
        private CategoriaProductos? categoria = null;
        private Proveedores? proveedor = null;
        private Inventarios? inventario = null;

        public TestDetalleVentas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioDetalleVentas = new DetalleVentasAplicacion(this.conexion);
            this.servicioVentas = new VentasAplicacion(this.conexion);
            this.servicioProductos = new ProductosAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
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
            this.empleado = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleado = this.servicioEmpleados.Insertar(this.empleado);

            this.venta = GeneradorDatosPrueba.ObtenerVenta(this.empleado.IdEmpleado);
            this.venta = this.servicioVentas.Insertar(this.venta);

            this.categoria = GeneradorDatosPrueba.ObtenerCategoriaProducto();
            this.categoria = this.servicioCategorias.Insertar(this.categoria);

            this.proveedor = GeneradorDatosPrueba.ObtenerProveedor();
            this.proveedor = this.servicioProveedores.Insertar(this.proveedor);

            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            this.producto = GeneradorDatosPrueba.ObtenerProducto(this.categoria.IdCategoria, this.proveedor.IdProveedor, this.inventario.IdInventario);
            this.producto = this.servicioProductos.Insertar(this.producto);

            this.entidad = GeneradorDatosPrueba.ObtenerDetalleVenta(this.venta.IdVenta, this.producto.IdProducto);
            this.entidad = this.servicioDetalleVentas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<DetalleVentas> lista = this.servicioDetalleVentas.Consultar();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Cantidad = 4;
            this.entidad.PrecioUnitario = 14500;

            var entry = this.conexion.Entry<DetalleVentas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
        
            if (this.entidad != null)
            {
                this.servicioDetalleVentas.Borrar(this.entidad);
            }

            if (this.venta != null)
            {
                this.servicioVentas.Borrar(this.venta);
            }
            
            if (this.producto != null)
            {
                this.servicioProductos.Borrar(this.producto);
            }

            
            if (this.proveedor != null)
            {
                this.servicioProveedores.Borrar(this.proveedor);
            }

            if (this.inventario != null)
            {
                this.servicioInventarios.Borrar(this.inventario);
            }

            if (this.categoria != null)
            {
                this.servicioCategorias.Borrar(this.categoria);
            }

            if (this.empleado != null)
            {
                this.servicioEmpleados.Borrar(this.empleado);
            }
        }
    }
}