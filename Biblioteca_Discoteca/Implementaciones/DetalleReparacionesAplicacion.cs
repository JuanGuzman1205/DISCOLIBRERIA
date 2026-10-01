using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class DetalleReparacionesAplicacion :IDetalleReparacionesAplicacion
    {
        private IConexion conexion;
        public DetalleReparacionesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public DetalleReparaciones Insertar(DetalleReparaciones entidad)
        {
            this.conexion.DetalleReparaciones!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<DetalleReparaciones> Consultar()
        {
            return this.conexion.DetalleReparaciones!
                .ToList();
        }
        public DetalleReparaciones Actualizar(DetalleReparaciones entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<DetalleReparaciones>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public DetalleReparaciones Borrar(DetalleReparaciones entidad)
        {
            this.conexion.DetalleReparaciones!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
