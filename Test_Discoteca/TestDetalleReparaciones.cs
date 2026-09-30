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
    public class TestDetalleReparaciones
    {
        private IConexion conexion;
        private DetalleReparaciones? entidad = null;

        public TestDetalleReparaciones()
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
            this.entidad = new DetalleReparaciones()
            {
                IdReparacion = 1,
                IdElementoInterno = 1,
                DescripcionReparacion = "Cambio de luces fundidas",
                CostoReparacion = 85000
            };

            this.conexion.DetalleReparaciones!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.DetalleReparaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.DescripcionReparacion = "Cambio de luces fundidas y cableado";
            this.entidad!.CostoReparacion = 120000;

            var entry = this.conexion!.Entry<DetalleReparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.DetalleReparaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}