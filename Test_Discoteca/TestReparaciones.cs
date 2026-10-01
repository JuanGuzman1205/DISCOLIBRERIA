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
    public class TestReparaciones
    {
        private IConexion conexion;
        private Reparaciones? entidad = null;
        public TestReparaciones()
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
            var empleado = this.conexion.Empleados!.FirstOrDefault();

            if (empleado == null)
            {
                empleado = new Empleados()
                {
                    Nombre = "Andrés",
                    Telefono = "3000000003",
                    Cargo = "Encargado",
                    Nomina = 180000000
                };

                this.conexion.Empleados!.Add(empleado);
                this.conexion.SaveChanges();
            }

            this.entidad = new Reparaciones()
            {
                IdSolicitante = empleado.IdEmpleado,
                IdEncargado = empleado.IdEmpleado,
                FechaReparacion = DateTime.Now
            };

            this.conexion.Reparaciones!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Reparaciones!.ToList();
            if (lista.Count <= 0)
                throw new Exception("No hay reparaciones registradas");
        }

        private void Actualizar()
        {
            this.entidad!.FechaReparacion = new DateTime(2026, 9, 23);

            var entry = this.conexion!.Entry<Reparaciones>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Reparaciones!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }

    }
}
