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
    public class TestProductos
    {
        private IConexion conexion;
        private IProductosAplicacion servicioProductos;
        private ICategoriaProductosAplicacion servicioCategorias;
        private IProveedoresAplicacion servicioProveedores;
        private IInventariosAplicacion servicioInventarios;

        private Productos? entidad = null;
        private CategoriaProductos? categoria = null;
        private Proveedores? proveedor = null;
        private Inventarios? inventario = null;

        public TestProductos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

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
            this.categoria = GeneradorDatosPrueba.ObtenerCategoriaProducto();
            this.categoria = this.servicioCategorias.Insertar(this.categoria);

            this.proveedor = GeneradorDatosPrueba.ObtenerProveedor();
            this.proveedor = this.servicioProveedores.Insertar(this.proveedor);

            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            this.entidad = GeneradorDatosPrueba.ObtenerProducto(
                this.categoria.IdCategoria,
                this.proveedor.IdProveedor,
                this.inventario.IdInventario
            );
            this.entidad = this.servicioProductos.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Productos> lista = this.servicioProductos.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No hay productos registrados");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Presentacion = "Garrafa";
            this.entidad.PrecioCompra = 230000;
            this.entidad.PrecioVenta = 500000;

            var entry = this.conexion.Entry<Productos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioProductos.Borrar(this.entidad);
            }

            if (this.categoria != null)
            {
                this.servicioCategorias.Borrar(this.categoria);
            }

            if (this.proveedor != null)
            {
                this.servicioProveedores.Borrar(this.proveedor);
            }

            if (this.inventario != null)
            {
                this.servicioInventarios.Borrar(this.inventario);
            }
        }
    }
}