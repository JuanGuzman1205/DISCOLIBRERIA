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
    public class TestCompras
    {
        private IConexion conexion;
        private IEmpleadosAplicacion servicioEmpleados;
        private IComprasAplicacion servicioCompras;

        private Compras? entidad = null;
        private Empleados? empleado = null;

        public TestCompras()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioCompras = new ComprasAplicacion(this.conexion);
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

            this.entidad = GeneradorDatosPrueba.ObtenerCompra(this.empleado.IdEmpleado);
            this.entidad = this.servicioCompras.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Compras> lista = this.servicioCompras.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista de compras vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.Total = 600000;

            var entry = this.conexion.Entry<Compras>(this.entidad);
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