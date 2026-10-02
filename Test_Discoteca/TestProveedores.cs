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
        private IProveedoresAplicacion servicioProveedores;
        private Proveedores? entidad = null;

        public TestProveedores()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();
            this.servicioProveedores = new ProveedoresAplicacion(conexion);
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

            
            this.entidad = this.servicioProveedores.Insertar(this.entidad);
        }

        public void Consultar()
        {
            
            this.servicioProveedores.Consultar();
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Diageo Colombia";
            this.entidad!.Telefono = "604 555 55 55";
            this.entidad!.Email = "LicoresImportados@diageocolombia.com";

            var entry = this.conexion.Entry<Proveedores>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.entidad is not null)
            {
               
                this.servicioProveedores.Borrar(this.entidad);
            }
        }

    }
}
