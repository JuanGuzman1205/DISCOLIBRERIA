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
    public class TestMesas
    {
        private IConexion conexion;
        private IMesasAplicacion servicioMesas;
        private Mesas? entidad = null;

        public TestMesas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

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
            this.entidad = GeneradorDatosPrueba.ObtenerMesa();
            this.entidad = this.servicioMesas.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<Mesas> lista = this.servicioMesas.Consultar();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de mesas");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.ConsumoMinimo = 350000;
            this.entidad.Ubicacion = "VIP 1";
            this.entidad.Capacidad = 8;

            var entry = this.conexion.Entry<Mesas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a borrar no existe.");

            this.servicioMesas.Borrar(this.entidad);
        }
    }
}