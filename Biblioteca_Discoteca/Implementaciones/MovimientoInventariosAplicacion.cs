using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class MovimientoInventariosAplicacion : IMovimientoInventariosAplicacion
    {
        private IConexion conexion;
        public MovimientoInventariosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public MovimientoInventarios Insertar(MovimientoInventarios entidad)
        {
            this.conexion.MovimientoInventarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<MovimientoInventarios> Consultar()
        {
            return this.conexion.MovimientoInventarios!
                .ToList();
        }
        public MovimientoInventarios Actualizar(MovimientoInventarios entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<MovimientoInventarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public MovimientoInventarios Borrar(MovimientoInventarios entidad)
        {
            this.conexion.MovimientoInventarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
