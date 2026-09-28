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
    public class TestClientes
    {
        private IConexion conexion;
        private Clientes? entidad = null;
        public TestClientes()
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
            this.entidad = new Clientes()
            {
                Nombre = "Eudosio",
                Apellido = "Jimenez"
            };
            this.conexion.Clientes!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Clientes!.ToList();
            if (lista.Count <= 0) {
                throw new Exception("Lista vacia");
            }
        }

        private void Actualizar()
        {
            this.entidad!.Apellido = "Gomez";

            var entry = this.conexion!.Entry<Clientes>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar() 
        {
            this.conexion.Clientes!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}