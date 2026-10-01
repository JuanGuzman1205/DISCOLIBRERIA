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
    public class TestEmpleados
    {
        private IConexion conexion;
        private IEmpleadosAplicacion servicioEmpleados;
        private Empleados? entidad = null;

        public TestEmpleados()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

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
            this.entidad = GeneradorDatosPrueba.ObtenerEmpleado();
            this.entidad = this.servicioEmpleados.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Empleados> lista = this.servicioEmpleados.Consultar();
            if (lista.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Cargo = "Barra";

            var entry = this.conexion.Entry<Empleados>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a borrar no existe.");

            this.servicioEmpleados.Borrar(this.entidad);
        }
    }
}