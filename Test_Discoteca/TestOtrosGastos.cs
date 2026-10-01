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
    public class TestOtrosGastos
    {
        private IConexion conexion;
        private IOtrosGastosAplicacion servicioOtrosGastos;
        private IEmpleadosAplicacion servicioEmpleados;

        private OtrosGastos? entidad = null;
        private Empleados? empleado = null;

        public TestOtrosGastos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioOtrosGastos = new OtrosGastosAplicacion(this.conexion);
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

            this.entidad = GeneradorDatosPrueba.ObtenerOtroGasto(this.empleado.IdEmpleado);
            this.entidad = this.servicioOtrosGastos.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<OtrosGastos> lista = this.servicioOtrosGastos.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No hay gastos registrados");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Descripcion = "Ajuste de Precio de la copa de vidrio";
            this.entidad.Monto = 15000;

            var entry = this.conexion.Entry<OtrosGastos>(this.entidad);
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