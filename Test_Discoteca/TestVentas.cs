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
    public class TestVentas
    {
        private IConexion conexion;
        private IVentasAplicacion servicioVentas;
        private IFacturasAplicacion servicioFacturas;
        private IEmpleadosAplicacion servicioEmpleados;
        private IClientesAplicacion servicioClientes;
        private IMetodosPagoAplicacion servicioMetodosPagos;

        private Ventas? entidad = null;
        private Facturas? factura = null;
        private Empleados? empleadoVentas = null;
        private Empleados? empleadoMesero = null;
        private Empleados? empleadoBarra = null;
        private Empleados? empleadoResponsableCaja = null;
        private Cajas? caja = null;
        private Clientes? cliente = null;
        private MetodosPagos? metodoPago = null;

        public TestVentas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioVentas = new VentasAplicacion(this.conexion);
            this.servicioFacturas = new FacturasAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioClientes = new ClientesAplicacion(this.conexion);
            this.servicioMetodosPagos = new MetodosPagosAplicacion(this.conexion);
        }

        [TestMethod]
        public void Execute()
        {
            //Insertar();
            //Consultar();
            //Actualizar();
            //Borrar();
        }

        public void Insertar()
        {
            this.empleadoVentas = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoVentas = this.servicioEmpleados.Insertar(this.empleadoVentas);

            this.empleadoMesero = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoMesero = this.servicioEmpleados.Insertar(this.empleadoMesero);

            this.empleadoBarra = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoBarra = this.servicioEmpleados.Insertar(this.empleadoBarra);

            this.empleadoResponsableCaja = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoResponsableCaja = this.servicioEmpleados.Insertar(this.empleadoResponsableCaja);

            this.caja = new Cajas()
            {
                IdEmpleadoCaja = this.empleadoResponsableCaja!.IdEmpleado
            };
            this.conexion.Cajas!.Add(this.caja);
            this.conexion.SaveChanges();

            this.cliente = GeneradorDatosPrueba.ObtenerCliente();
            this.cliente = this.servicioClientes.Insertar(this.cliente);

            this.metodoPago = GeneradorDatosPrueba.ObtenerMetodoPago(this.cliente!.IdCliente);
            this.metodoPago = this.servicioMetodosPagos.Insertar(this.metodoPago);

            this.entidad = new Ventas()
            {
                IdEmpleado = this.empleadoVentas!.IdEmpleado,
                IdFactura = null,
                Total = 150700,
                Estado = true
            };
            this.entidad = this.servicioVentas.Insertar(this.entidad);

            this.factura = GeneradorDatosPrueba.ObtenerFactura(
                this.entidad!.IdVenta,
                this.empleadoMesero!.IdEmpleado,
                this.empleadoBarra!.IdEmpleado,
                this.caja!.IdCaja,
                this.metodoPago!.IdMetodoPago
            );
            this.factura = this.servicioFacturas.Insertar(this.factura);

            this.entidad!.IdFactura = this.factura!.IdFactura;
            var entry = this.conexion.Entry<Ventas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            List<Ventas> lista = this.servicioVentas.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No hay ventas registradas");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Estado = false;

            var entry = this.conexion.Entry<Ventas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null) this.servicioVentas.Borrar(this.entidad);
            if (this.factura != null) this.servicioFacturas.Borrar(this.factura);
            if (this.metodoPago != null) this.servicioMetodosPagos.Borrar(this.metodoPago);
            if (this.cliente != null) this.servicioClientes.Borrar(this.cliente);

            if (this.caja != null)
            {
                this.conexion.Cajas!.Remove(this.caja);
                this.conexion.SaveChanges();
            }

            if (this.empleadoResponsableCaja != null) this.servicioEmpleados.Borrar(this.empleadoResponsableCaja);
            if (this.empleadoBarra != null) this.servicioEmpleados.Borrar(this.empleadoBarra);
            if (this.empleadoMesero != null) this.servicioEmpleados.Borrar(this.empleadoMesero);
            if (this.empleadoVentas != null) this.servicioEmpleados.Borrar(this.empleadoVentas);
        }
    }
}