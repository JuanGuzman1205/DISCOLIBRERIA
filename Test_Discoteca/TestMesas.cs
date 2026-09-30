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
    public class TestMesas
    {
        private IConexion conexion;
        private Mesas? entidad = null;
        public TestMesas()
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
            this.entidad = new Mesas()
            {
                ConsumoMinimo = 121000,
                Ubicacion = "Mesa Alta 1",
                Capacidad = 4
            };
            this.conexion.Mesas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Mesas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de mesas");
        }

        private void Actualizar()
        {
            this.entidad!.ConsumoMinimo = 350000;
            this.entidad!.Ubicacion = "VIP 1";
            this.entidad!.Capacidad = 8;

            var entry = this.conexion!.Entry<Mesas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Mesas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
