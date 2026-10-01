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
    public class TestEventos
    {
        private IConexion conexion;
        private IEventosAplicacion servicioEventos;
        private IEmpleadosAplicacion servicioEmpleados;

        private Eventos? entidad = null;
        private Empleados? empleado = null;

        public TestEventos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioEventos = new EventosAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
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
            this.empleado = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleado = this.servicioEmpleados.Insertar(this.empleado);

            this.entidad = GeneradorDatosPrueba.ObtenerEvento(this.empleado.IdEmpleado);
            this.entidad = this.servicioEventos.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Eventos> lista = this.servicioEventos.Consultar();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.DetalleEvento = "Fiesta de Halloween (VIP)";
            this.entidad.HoraFin = new DateTime(2026, 11, 1, 5, 0, 0);

            var entry = this.conexion.Entry<Eventos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.empleado != null)
            {
                this.servicioEmpleados.Borrar(this.empleado);
            }
        }
    }
}