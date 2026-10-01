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
    public class TestFacturas
    {
        private IConexion conexion;
        private IFacturasAplicacion servicioFacturas;
        private IVentasAplicacion servicioVentas;
        private IEmpleadosAplicacion servicioEmpleados;
        private ICajasAplicacion servicioCajas;
        private IMetodosPagoAplicacion servicioMetodosPago;
        

        private Facturas? entidad = null;
        private Ventas? venta = null;
        private Empleados? mesero = null;
        private Empleados? barra = null;
        private Cajas? caja = null;
        private MetodosPagos? metodoPago = null;
        private MetodosPagos? nuevoMetodoPago = null;

        public TestFacturas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioFacturas = new FacturasAplicacion(this.conexion);
            this.servicioVentas = new VentasAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioCajas = new CajasAplicacion(this.conexion);
            this.servicioMetodosPago = new MetodosPagosAplicacion(this.conexion);
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
            // 1. Crear empleados necesarios (Mesero y Barra)
            this.mesero = GeneradorDatosPrueba.ObtenerEmpleado();
            this.mesero = this.servicioEmpleados.Insertar(this.mesero);

            this.barra = GeneradorDatosPrueba.ObtenerEmpleado();
            this.barra.Nombre = "Barman";
            this.barra = this.servicioEmpleados.Insertar(this.barra);

            // 2. Crear Caja vinculada al mesero/empleado
            this.caja = GeneradorDatosPrueba.ObtenerCaja(this.mesero.IdEmpleado);
            this.caja = this.servicioCajas.Insertar(this.caja);

            // 3. Crear Venta vinculada al empleado
            this.venta = GeneradorDatosPrueba.ObtenerVenta(this.mesero.IdEmpleado);
            this.venta = this.servicioVentas.Insertar(this.venta);

            // 4. Crear Método de Pago
            this.metodoPago = GeneradorDatosPrueba.ObtenerMetodoPago();
            this.metodoPago = this.servicioMetodosPago.Insertar(this.metodoPago);

            // 5. Crear la Factura usando los IDs generados dinámicamente
            this.entidad = GeneradorDatosPrueba.ObtenerFactura(
                this.venta.IdVenta,
                this.mesero.IdEmpleado,
                this.barra.IdEmpleado,
                this.caja.IdCaja,
                this.metodoPago.IdMetodoPago
            );
            this.entidad = this.servicioFacturas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Facturas> lista = this.servicioFacturas.Consultar();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            // Creamos un segundo método de pago para probar el cambio de ID dinámicamente
            nuevoMetodoPago = GeneradorDatosPrueba.ObtenerMetodoPago();
            nuevoMetodoPago.TipoMetodoPago = "Transferencia";
            nuevoMetodoPago = this.servicioMetodosPago.Insertar(nuevoMetodoPago);

            this.entidad.IdMetodoPago = nuevoMetodoPago.IdMetodoPago;

            var entry = this.conexion.Entry<Facturas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioFacturas.Borrar(this.entidad);
            }

            if (this.venta != null)
            {
                this.servicioVentas.Borrar(this.venta);
            }

            if (this.mesero != null)
            {
                this.servicioEmpleados.Borrar(this.mesero);
            }

            if (this.barra != null)
            {
                this.servicioEmpleados.Borrar(this.barra);
            }

            if (this.metodoPago != null)
            {
                this.servicioMetodosPago.Borrar(this.metodoPago);
            }
            if (this.nuevoMetodoPago != null)
            {
                this.servicioMetodosPago.Borrar(this.nuevoMetodoPago);
            }
        }
    }
}