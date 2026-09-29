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
    public class TestCajas
    {
        private IConexion conexion;
        private Cajas? entidad = null;
        public TestCajas() 
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
            this.entidad = new Cajas()
            {
                IdEmpleadoCaja = 1,
                DineroInicial = 500000,
                DineroFinal = 0,
                Ganancias = 0
            };
            this.conexion.Cajas!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }
        public void Consultar() 
        {
            var lista = this.conexion.Cajas!.ToList();
            if (lista.Count <= 0)
                throw new Exception("Lista Vacia");
        }
        private void Actualizar()
        {
            this.entidad!.DineroFinal = 1100000;
            this.entidad!.Ganancias = 600000;

            var entry = this.conexion.Entry<Cajas>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }
        private void Borrar()
        { 
            this.conexion.Cajas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
