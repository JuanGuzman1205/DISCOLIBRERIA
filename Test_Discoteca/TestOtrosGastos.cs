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
    public class TestOtrosGastos
    {
        private IConexion conexion;
        private OtrosGastos? entidad = null;
        public TestOtrosGastos()
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
            this.entidad = new OtrosGastos()
            {
                IdEmpleado = 1,
                Descripcion = "Copa de vidrio",
                Monto = 10000,
                FechaGasto = DateTime.Now
            };
            this.conexion.OtrosGastos!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.OtrosGastos!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No hay gastos registrados");
        }

        private void Actualizar()
        {
            this.entidad!.Descripcion = "Ajuste de Precio de la copa de vidrio";
            this.entidad!.Monto = 15000;

            var entry = this.conexion!.Entry<OtrosGastos>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.OtrosGastos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
