using Biblioteca_Discoteca.Implementaciones;
using Biblioteca_Discoteca.Interfaces;
using Biblioteca_Discoteca.Nucleo;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test_Discoteca
{
    [TestClass]
    public class TestElementosInternos
    {
        private IConexion conexion;
        private IElementosInternosAplicacion servicioElementosInternos;
        private IInventariosAplicacion servicioInventarios;

        private ElementosInternos? entidad = null;
        private Inventarios? inventario = null;

        public TestElementosInternos()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = DatosGenerales.ObtenerStringConexion();

            this.servicioElementosInternos = new ElementosInternosAplicacion(this.conexion);
            this.servicioInventarios = new InventariosAplicacion(this.conexion);
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
            this.inventario = GeneradorDatosPrueba.ObtenerInventario();
            this.inventario = this.servicioInventarios.Insertar(this.inventario);

            this.entidad = GeneradorDatosPrueba.ObtenerElementoInterno(this.inventario.IdInventario);
            this.entidad = this.servicioElementosInternos.Insertar(this.entidad);
        }

        public void Consultar()
        {
            List<ElementosInternos> lista = this.servicioElementosInternos.Consultar();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            if (this.entidad == null)
                throw new Exception("La entidad a actualizar no existe.");

            this.entidad.NombreElementoInterno = "Luces LED RGB";
            this.entidad.CantidadElementoInterno = 18;
            this.entidad.PrecioElementoInterno = 50000m;

            var entry = this.conexion.Entry<ElementosInternos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            if (this.inventario != null)
            {
                this.servicioInventarios.Borrar(this.inventario);
            }
        }
    }
}