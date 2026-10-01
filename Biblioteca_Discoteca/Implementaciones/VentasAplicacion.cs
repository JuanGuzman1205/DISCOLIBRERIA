using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class VentasAplicacion : IVentasAplicacion
    {
        private IConexion conexion;
        public VentasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Ventas Insertar(Ventas entidad)
        {
            this.conexion.Ventas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Ventas> Consultar()
        {
            return this.conexion.Ventas!
                .ToList();
        }
        public Ventas Actualizar(Ventas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Ventas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Ventas Borrar(Ventas entidad)
        {
            this.conexion.Ventas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
