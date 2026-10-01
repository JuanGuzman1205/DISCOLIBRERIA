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
    public class TestMovimientoInventarios
    {
        private IConexion conexion;
        private IMovimientoInventariosAplicacion servicioMovimientoInventarios;
        private IInventariosAplicacion servicioInventarios;

        private MovimientoInventarios? entidad = null;
        private Inventarios? inventario = null;

        public TestMovimientoInventarios()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioMovimientoInventarios = new MovimientoInventariosAplicacion(this.conexion);
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
            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            this.entidad = GeneradorDatosPrueba.ObtenerMovimientoInventario(this.inventario.IdInventario);
            this.entidad = this.servicioMovimientoInventarios.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<MovimientoInventarios> lista = this.servicioMovimientoInventarios.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de movimientos en el inventario");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Cantidad = 5;
            this.entidad.TipoMovimiento = "Salida";

            var entry = this.conexion.Entry<MovimientoInventarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioMovimientoInventarios.Borrar(this.entidad);
            }

            if (this.inventario != null)
            {
                this.servicioInventarios.Borrar(this.inventario);
            }
        }
    }
}