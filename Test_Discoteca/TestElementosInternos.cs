using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Discoteca
{
    [TestClass]
    public class TestElementosInternos
    {
        private IConexion conexion;
        private ElementosInternos? entidad = null;

        public TestElementosInternos()
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
            this.entidad = new ElementosInternos()
            {
                IdInventario = 1,
                NombreElementoInterno = "Luces LED",
                CantidadElementoInterno = 20,
                PrecioElementoInterno = 45000m
            };

            this.conexion.ElementosInternos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.ElementosInternos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.NombreElementoInterno = "Luces LED RGB";
            this.entidad!.CantidadElementoInterno = 18;
            this.entidad!.PrecioElementoInterno = 50000m;

            var entry = this.conexion!.Entry<ElementosInternos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.ElementosInternos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
