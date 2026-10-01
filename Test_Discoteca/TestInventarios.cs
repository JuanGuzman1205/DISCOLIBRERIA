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
    public class TestInventarios
    {
        private IConexion conexion;
        private IInventariosAplicacion servicioInventarios;
        private Inventarios? entidad = null;

        public TestInventarios()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

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
            this.entidad = GeneradorDatosPrueba.ObtenerInventario();
            this.entidad = this.servicioInventarios.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Inventarios> lista = this.servicioInventarios.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de inventario");
        }

        private void Actualizar()
        {
            // Debido a que el inventario solo maneja el ID por el momento, se deja como operación nula para mantener el flujo de la prueba
        }

        private void Borrar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a borrar no existe.");

            this.servicioInventarios.Borrar(this.entidad);
        }
    }
}