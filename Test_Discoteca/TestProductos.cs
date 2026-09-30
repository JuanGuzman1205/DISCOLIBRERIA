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
    public class TestProductos
    {
        private IConexion conexion;
        private Productos? entidad = null;
        public TestProductos()
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
            this.entidad = new Productos()
            {
                IdCategoria = 1,
                IdProveedor = 1,
                IdInventario = 1,
                NomProducto = "Jack Daniels Honey",
                Presentacion = "Botella 750ml",
                PrecioCompra = 150000,
                PrecioVenta = 330000
            };
            this.conexion.Productos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Productos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No hay productos registrados");
        }

        private void Actualizar()
        {
            this.entidad!.Presentacion = "Garrafa";
            this.entidad!.PrecioCompra = 230000;
            this.entidad!.PrecioVenta = 500000;

            var entry = this.conexion!.Entry<Productos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Productos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
