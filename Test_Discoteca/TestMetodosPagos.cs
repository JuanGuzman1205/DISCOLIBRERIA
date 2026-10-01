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
    public class TestMetodosPagos
    {
        private IConexion conexion;
        private MetodosPagos? entidad = null;
        public TestMetodosPagos()
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
                    Apellido = "Guzman"
                };

                this.conexion.Clientes!.Add(cliente);
                this.conexion.SaveChanges();
            }

            this.entidad = new MetodosPagos()
            {
                IdCliente = cliente.IdCliente,
                TipoMetodoPago = "Efectivo",
                NumeroCuenta = null
            };

            this.conexion.MetodosPagos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.MetodosPagos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No se encontraron registros de métodos de pago");
        }

        private void Actualizar()
        {
            this.entidad!.TipoMetodoPago = "Tarjeta de Crédito";
            this.entidad!.NumeroCuenta = "987654321";

            var entry = this.conexion!.Entry<MetodosPagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.MetodosPagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
