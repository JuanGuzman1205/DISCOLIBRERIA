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
    public class TestProveedores
    {
        private IConexion conexion;
        private Proveedores? entidad = null;
        public TestProveedores()
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
            this.entidad = new Proveedores()
            {
                Nombre = "Fabrica de Licores de Antioquia (FLA)",
                Telefono = "604 444 44 44",
                Email = "FabricalicoresAntioquia@fla.com"
            };
            this.conexion.Proveedores!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Proveedores!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No hay proveedores registrados");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Diageo Colombia";
            this.entidad!.Telefono = "604 555 55 55";
            this.entidad!.Email = "LicoresImportados@diageocolombia.com";

            var entry = this.conexion!.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
