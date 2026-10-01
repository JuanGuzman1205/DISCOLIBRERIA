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
    public class TestCategoriaProductos
    {
        private IConexion conexion;
        private ICategoriaProductosAplicacion servicioCategoria;
        private CategoriaProductos? entidad = null;

        public TestCategoriaProductos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioCategoria = new CategoriaProductosAplicacion(this.conexion);
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
            this.entidad = GeneradorDatosPrueba.ObtenerCategoriaProducto();
            this.entidad = this.servicioCategoria.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<CategoriaProductos> lista = this.servicioCategoria.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista Vacia");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.NomCategoria = "Energizantes";

            var entry = this.conexion.Entry<CategoriaProductos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a borrar no existe.");

            this.servicioCategoria.Borrar(this.entidad);
        }
    }
}