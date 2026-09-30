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
    public class TestMovimientoInventarios
    {
        private IConexion conexion;
        private MovimientoInventarios? entidad = null;
        public TestMovimientoInventarios()
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
            this.entidad = new MovimientoInventarios()
            {
                IdInventario = 1,
                TipoMovimiento = "Entrada",
                Cantidad = 20,
                FechaMovimiento = DateTime.Now
            };
            this.conexion.MovimientoInventarios!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.MovimientoInventarios!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de movimientos en el inventario");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 5;
            this.entidad!.TipoMovimiento = "Salida";

            var entry = this.conexion!.Entry<MovimientoInventarios>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.MovimientoInventarios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
