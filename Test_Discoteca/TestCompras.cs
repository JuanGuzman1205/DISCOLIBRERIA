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
    public class TestCompras
    {
        private IConexion conexion;
        private Compras? entidad = null;

        public TestCompras()
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
            this.entidad = new Compras()
            {
                IdEmpleado = 1,
                Total = 550000,
                Fecha = DateTime.Now
            };

            this.conexion.Compras!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Compras!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista de compras vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Total = 600000;

            var entry = this.conexion!.Entry<Compras>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Compras!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
