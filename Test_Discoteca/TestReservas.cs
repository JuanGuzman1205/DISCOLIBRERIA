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
    public class TestReservas
    {
        private IConexion conexion;
        private IReservasAplicacion servicioReservas;
        private IClientesAplicacion servicioClientes;

        private Reservas? entidad = null;
        private Clientes? cliente = null;

        public TestReservas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioReservas = new ReservasAplicacion(this.conexion);
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

            this.entidad = new Reservas()
            {
                IdCliente = this.cliente.IdCliente,
                FechaReserva = new DateTime(2026, 10, 3),
                Total = 80000
            };

            this.entidad = this.servicioReservas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Reservas> lista = this.servicioReservas.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No hay reservas registradas");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.FechaReserva = new DateTime(2026, 10, 2);

            var entry = this.conexion.Entry<Reservas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioReservas.Borrar(this.entidad);
            }

            if (this.cliente != null)
            {
                this.servicioClientes.Borrar(this.cliente);
            }
        }
    }
}