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
    public class TestReservas
    {
        private IConexion conexion;
        private Reservas? entidad = null;
        public TestReservas()
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
            var cliente = this.conexion.Clientes!.FirstOrDefault();

            if (cliente == null)
            {
                cliente = new Clientes()
                {
                    Nombre = "Juan",
                    Apellido = "Morales"
                };

                this.conexion.Clientes!.Add(cliente);
                this.conexion.SaveChanges();
            }

            this.entidad = new Reservas()
            {
                IdCliente = cliente.IdCliente,
                FechaReserva = new DateTime(2026, 10, 3),
                Total = 80000
            };

            this.conexion.Reservas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Reservas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No hay reservas registradas");
        }

        private void Actualizar()
        {
            this.entidad!.FechaReserva = new DateTime(2026, 10, 2);

            var entry = this.conexion!.Entry<Reservas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Reservas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
