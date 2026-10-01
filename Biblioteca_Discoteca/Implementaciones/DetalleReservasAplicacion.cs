using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class DetalleReservasAplicacion : IDetalleReservasAplicacion
    {
        private IConexion conexion;
        public DetalleReservasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public DetalleReservas Insertar(DetalleReservas entidad)
        {
            this.conexion.DetalleReservas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<DetalleReservas> Consultar()
        {
            return this.conexion.DetalleReservas!
                .ToList();
        }
        public DetalleReservas Actualizar(DetalleReservas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<DetalleReservas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public DetalleReservas Borrar(DetalleReservas entidad)
        {
            this.conexion.DetalleReservas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
