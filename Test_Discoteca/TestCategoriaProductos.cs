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
    public class TestCategoriaProductos
    {
        private IConexion conexion;
        private CategoriaProductos? entidad = null;
        public TestCategoriaProductos()
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
            this.entidad = new CategoriaProductos()
            {
                NomCategoria = "Aguardientes"
            };
            this.conexion.CategoriaProductos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar()
        {
            var lista = this.conexion.CategoriaProductos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista Vacia");
        }
        private void Actualizar()
        {
            this.entidad!.NomCategoria = "Energizantes";

            var entry = this.conexion.Entry<CategoriaProductos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }
        private void Borrar()
        {
            this.conexion.CategoriaProductos!.Remove(this.entidad!);
            this.conexion.SaveChanges();

        }
    }
}
