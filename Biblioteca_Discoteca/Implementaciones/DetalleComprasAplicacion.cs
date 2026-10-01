using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class DetalleComprasAplicacion : IDetalleComprasAplicacion
    {
        private IConexion conexion;
        public DetalleComprasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public DetalleCompras Insertar(DetalleCompras entidad)
        {
            this.conexion.DetalleCompras!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<DetalleCompras> Consultar()
        {
            return this.conexion.DetalleCompras!
                .ToList();
        }
        public DetalleCompras Actualizar(DetalleCompras entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<DetalleCompras>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public DetalleCompras Borrar(DetalleCompras entidad)
        {
            this.conexion.DetalleCompras!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
