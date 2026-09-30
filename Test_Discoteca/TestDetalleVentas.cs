using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Discoteca
{
    [TestClass]
    public class TestDetalleVentas
    {
        private IConexion conexion;
        private DetalleVentas? entidad = null;

        public TestDetalleVentas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();
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
            this.entidad = new DetalleVentas()
            {
                IdVenta = 1,
                IdProducto = 1,
                Cantidad = 2,
                PrecioUnitario = 15000
            };

            this.conexion.DetalleVentas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetalleVentas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 4;
            this.entidad!.PrecioUnitario = 14500;

            var entry = this.conexion!.Entry<DetalleVentas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetalleVentas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
