using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class MesasAplicacion :IMesasAplicacion
    {
        private IConexion conexion;
        public MesasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Mesas Insertar(Mesas entidad)
        {
            this.conexion.Mesas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Mesas> Consultar()
        {
            return this.conexion.Mesas!
                .ToList();
        }
        public Mesas Actualizar(Mesas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Mesas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Mesas Borrar(Mesas entidad)
        {
            this.conexion.Mesas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
