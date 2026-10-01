using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ReservasAplicacion : IReservasAplicacion
    {
        private IConexion conexion;
        public ReservasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Reservas Insertar(Reservas entidad)
        {
            this.conexion.Reservas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Reservas> Consultar()
        {
            return this.conexion.Reservas!
                .ToList();
        }
        public Reservas Actualizar(Reservas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Reservas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Reservas Borrar(Reservas entidad)
        {
            this.conexion.Reservas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
