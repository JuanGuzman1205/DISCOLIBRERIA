using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ReparacionesAplicacion : IReparacionesAplicacion
    {
        private IConexion conexion;
        public ReparacionesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Reparaciones Insertar(Reparaciones entidad)
        {
            this.conexion.Reparaciones!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Reparaciones> Consultar()
        {
            return this.conexion.Reparaciones!
                .ToList();
        }
        public Reparaciones Actualizar(Reparaciones entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Reparaciones>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Reparaciones Borrar(Reparaciones entidad)
        {
            this.conexion.Reparaciones!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
