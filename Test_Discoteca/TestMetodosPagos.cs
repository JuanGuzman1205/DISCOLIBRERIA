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
    public class TestMetodosPagos
    {
        private IConexion conexion;
        private IMetodosPagoAplicacion servicioMetodosPagos;
        private IClientesAplicacion servicioClientes;

        private MetodosPagos? entidad = null;
        private Clientes? cliente = null;

        public TestMetodosPagos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioMetodosPagos = new MetodosPagosAplicacion(this.conexion);
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
            this.cliente = GeneradorDatosPrueba.ObtenerCliente();
            this.cliente = this.servicioClientes.Insertar(this.cliente);

            this.entidad = GeneradorDatosPrueba.ObtenerMetodoPago(this.cliente.IdCliente);
            this.entidad = this.servicioMetodosPagos.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<MetodosPagos> lista = this.servicioMetodosPagos.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de métodos de pago");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.TipoMetodoPago = "Tarjeta de Crédito";
            this.entidad.NumeroCuenta = "987654321";

            var entry = this.conexion.Entry<MetodosPagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioMetodosPagos.Borrar(this.entidad);
            }

            if (this.cliente != null)
            {
                this.servicioClientes.Borrar(this.cliente);
            }
        }
    }
}