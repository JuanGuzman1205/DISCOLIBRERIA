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
    public class TestClientes
    {
        private IConexion conexion;
        private IClientesAplicacion servicioClientes;
        private Clientes? entidad = null;

        public TestClientes()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioClientes = new ClientesAplicacion(this.conexion);
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
            this.entidad = GeneradorDatosPrueba.ObtenerCliente();
            this.entidad = this.servicioClientes.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Clientes> lista = this.servicioClientes.Consultar();

            if (lista.Count <= 0)
            {
                throw new Exception("Lista vacia");
            }
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Apellido = "Gomez";

            var entry = this.conexion.Entry<Clientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a borrar no existe.");

            this.servicioClientes.Borrar(this.entidad);
        }
    }
}