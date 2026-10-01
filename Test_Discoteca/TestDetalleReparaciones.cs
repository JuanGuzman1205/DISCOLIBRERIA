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
    public class TestDetalleReparaciones
    {
        private IConexion conexion;
        private IDetalleReparacionesAplicacion servicioDetalleReparaciones;
        private IReparacionesAplicacion servicioReparaciones;
        private IEmpleadosAplicacion servicioEmpleados;
        private IElementosInternosAplicacion servicioElementosInternos;
        private IInventariosAplicacion servicioInventarios;

        private DetalleReparaciones? entidad = null;
        private Reparaciones? reparacion = null;
        private Empleados? empleadoSolicitante = null;
        private Empleados? empleadoEncargado = null;
        private ElementosInternos? elementoInterno = null;
        private Inventarios? inventario = null;

        public TestDetalleReparaciones()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioDetalleReparaciones = new DetalleReparacionesAplicacion(this.conexion);
            this.servicioReparaciones = new ReparacionesAplicacion(this.conexion);
            this.servicioEmpleados = new EmpleadosAplicacion(this.conexion);
            this.servicioElementosInternos = new ElementosInternosAplicacion(this.conexion);
            this.servicioInventarios = new InventariosAplicacion(this.conexion);
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
            this.empleadoSolicitante = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoSolicitante = this.servicioEmpleados.Insertar(this.empleadoSolicitante);

            this.empleadoEncargado = GeneradorDatosPrueba.ObtenerEmpleado();
            this.empleadoEncargado.Nombre = "Encargado Reparacion";
            this.empleadoEncargado = this.servicioEmpleados.Insertar(this.empleadoEncargado);

            this.reparacion = GeneradorDatosPrueba.ObtenerReparacion(this.empleadoSolicitante.IdEmpleado, this.empleadoEncargado.IdEmpleado);
            this.reparacion = this.servicioReparaciones.Insertar(this.reparacion);

            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            this.elementoInterno = GeneradorDatosPrueba.ObtenerElementoInterno(this.inventario.IdInventario);
            this.elementoInterno = this.servicioElementosInternos.Insertar(this.elementoInterno);

            this.entidad = GeneradorDatosPrueba.ObtenerDetalleReparacion(this.reparacion.IdReparacion, this.elementoInterno.IdElementoInterno);
            this.entidad = this.servicioDetalleReparaciones.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<DetalleReparaciones> lista = this.servicioDetalleReparaciones.Consultar();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.DescripcionReparacion = "Cambio de luces fundidas y cableado";
            this.entidad.CostoReparacion = 120000;

            var entry = this.conexion.Entry<DetalleReparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.empleadoSolicitante != null) this.servicioEmpleados.Borrar(this.empleadoSolicitante);
            if (this.empleadoEncargado != null) this.servicioEmpleados.Borrar(this.empleadoEncargado);
            if (this.inventario != null) this.servicioInventarios.Borrar(this.inventario);
        }
    }
}