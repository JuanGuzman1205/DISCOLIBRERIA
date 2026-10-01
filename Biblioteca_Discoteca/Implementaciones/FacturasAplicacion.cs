using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class FacturasAplicacion : IFacturasAplicacion
    {
        private IConexion conexion;
        public FacturasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Facturas Insertar(Facturas entidad)
        {
            this.conexion.Facturas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Facturas> Consultar()
        {
            return this.conexion.Facturas!
                .ToList();
        }
        public Facturas Actualizar(Facturas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Facturas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Facturas Borrar(Facturas entidad)
        {
            this.conexion.Facturas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
