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
    public class TestEventos
    {
        private IConexion conexion;
        private Eventos? entidad = null;

        public TestEventos()
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
            this.entidad = new Eventos()
            {
                IdEncargado = 1,
                DetalleEvento = "Fiesta de Halloween",
                FechaEvento = new DateTime(2026, 10, 31),
                HoraInicio = new DateTime(2026, 10, 31, 20, 0, 0),
                HoraFin = new DateTime(2026, 11, 1, 4, 0, 0)
            };

            this.conexion.Eventos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Eventos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.DetalleEvento = "Fiesta de Halloween (VIP)";
            this.entidad!.HoraFin = new DateTime(2026, 11, 1, 5, 0, 0);

            var entry = this.conexion!.Entry<Eventos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Eventos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
