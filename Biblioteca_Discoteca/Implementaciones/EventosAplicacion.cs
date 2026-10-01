using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class EventosAplicacion : IEventosAplicacion
    {
        private IConexion conexion;
        public EventosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Eventos Insertar(Eventos entidad)
        {
            this.conexion.Eventos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Eventos> Consultar()
        {
            return this.conexion.Eventos!
                .ToList();
        }
        public Eventos Actualizar(Eventos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Eventos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Eventos Borrar(Eventos entidad)
        {
            this.conexion.Eventos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
