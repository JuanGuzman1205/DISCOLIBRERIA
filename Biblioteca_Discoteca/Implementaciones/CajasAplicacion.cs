using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class CajasAplicacion : ICajasAplicacion
    {
        private IConexion conexion;
        public CajasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Cajas Insertar(Cajas entidad)
        {
            this.conexion.Cajas!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Cajas> Consultar()
        {
            return this.conexion.Cajas!
                .ToList();
        }
        public Cajas Actualizar(Cajas entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Cajas>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Cajas Borrar(Cajas entidad)
        {
            this.conexion.Cajas!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
