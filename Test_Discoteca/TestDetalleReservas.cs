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
    public class TestDetalleReservas
    {
        private IConexion conexion;
        private IDetalleReservasAplicacion servicioDetalleReservas;
        private IReservasAplicacion servicioReservas;
        private IClientesAplicacion servicioClientes;
        private IMesasAplicacion servicioMesas;

        private DetalleReservas? entidad = null;
        private Reservas? reserva = null;
        private Clientes? cliente = null;
        private Mesas? mesa1 = null;
        private Mesas? mesa2 = null;

        public TestDetalleReservas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioDetalleReservas = new DetalleReservasAplicacion(this.conexion);
            this.servicioReservas = new ReservasAplicacion(this.conexion);
            this.servicioClientes = new ClientesAplicacion(this.conexion);
            this.servicioMesas = new MesasAplicacion(this.conexion);
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

            this.reserva = GeneradorDatosPrueba.ObtenerReserva(this.cliente.IdCliente);
            this.reserva = this.servicioReservas.Insertar(this.reserva);

            this.mesa1 = GeneradorDatosPrueba.ObtenerMesa();
            this.mesa1 = this.servicioMesas.Insertar(this.mesa1);

            this.entidad = GeneradorDatosPrueba.ObtenerDetalleReserva(this.reserva.IdReserva, this.mesa1.IdMesa);
            this.entidad = this.servicioDetalleReservas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<DetalleReservas> lista = this.servicioDetalleReservas.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.mesa2 = GeneradorDatosPrueba.ObtenerMesa();
            this.mesa2.Ubicacion = "VIP Terraza";
            this.mesa2 = this.servicioMesas.Insertar(this.mesa2);

            this.entidad.IdMesa = this.mesa2.IdMesa;

            var entry = this.conexion.Entry<DetalleReservas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.cliente != null)
            {
                this.servicioClientes.Borrar(this.cliente);
            }

            if (this.mesa1 != null)
            {
                this.servicioMesas.Borrar(this.mesa1);
            }

            if (this.mesa2 != null)
            {
                this.servicioMesas.Borrar(this.mesa2);
            }
        }
    }
}