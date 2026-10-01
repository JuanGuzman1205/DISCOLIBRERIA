using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class DetalleVentasAplicacion : IDetalleVentasAplicacion
    {
        private IConexion conexion;
        public DetalleVentasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public DetalleVentas Insertar(DetalleVentas entidad)
        {
            this.conexion.DetalleVentas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<DetalleVentas> Consultar()
        {
            return this.conexion.DetalleVentas!
                .ToList();
        }
        public DetalleVentas Actualizar(DetalleVentas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<DetalleVentas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public DetalleVentas Borrar(DetalleVentas entidad)
        {
            this.conexion.DetalleVentas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
