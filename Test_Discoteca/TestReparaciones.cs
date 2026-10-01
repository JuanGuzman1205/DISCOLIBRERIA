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
    public class TestReparaciones
    {
        private IConexion conexion;
        private IReparacionesAplicacion servicioReparaciones;
        private IEmpleadosAplicacion servicioEmpleados;

        private Reparaciones? entidad = null;
        private Empleados? empleado = null;

        public TestReparaciones()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioReparaciones = new ReparacionesAplicacion(this.conexion);
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

            this.entidad = new Reparaciones()
            {
                IdSolicitante = this.empleado.IdEmpleado,
                IdEncargado = this.empleado.IdEmpleado,
                FechaReparacion = DateTime.Now
            };

            this.entidad = this.servicioReparaciones.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Reparaciones> lista = this.servicioReparaciones.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No hay reparaciones registradas");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.FechaReparacion = new DateTime(2026, 9, 23);

            var entry = this.conexion.Entry<Reparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad != null)
            {
                this.servicioReparaciones.Borrar(this.entidad);
            }

            if (this.empleado != null)
            {
                this.servicioEmpleados.Borrar(this.empleado);
            }
        }
    }
}
