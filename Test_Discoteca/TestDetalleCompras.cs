using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Discoteca
{
    [TestClass]
    public class TestDetalleCompras
    {
        private IConexion conexion;
        private DetalleCompras? entidad = null;

        public TestDetalleCompras()
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
            this.entidad = new DetalleCompras()
            {
                IdCompra = 1,
                IdProducto = 1,
                Cantidad = 10,
                Total = 150000
            };

            this.conexion.DetalleCompras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()
        {
            var lista = this.conexion.DetalleCompras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }
        private void Actualizar()
        {
            this.entidad!.Cantidad = 15;
            this.entidad!.Total = 225000;

            var entry = this.conexion!.Entry<DetalleCompras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }
        private void Borrar()
        {
            this.conexion.DetalleCompras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

