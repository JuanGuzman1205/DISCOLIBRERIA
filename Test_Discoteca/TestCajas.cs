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
    public class TestCajas
    {
        private IConexion conexion;
        private IEmpleadosAplicacion servicioEmpleados;
        private ICajasAplicacion servicioCajas;

        private Cajas? entidad = null;
        private Empleados? empleado = null;

        public TestCajas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioCajas = new CajasAplicacion(this.conexion);
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

            this.entidad = GeneradorDatosPrueba.ObtenerCaja(this.empleado.IdEmpleado);
            this.entidad = this.servicioCajas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Cajas> lista = this.servicioCajas.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista Vacia");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.DineroFinal = 1100000;
            this.entidad.Ganancias = 600000;

            var entry = this.conexion.Entry<Cajas>(this.entidad);
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