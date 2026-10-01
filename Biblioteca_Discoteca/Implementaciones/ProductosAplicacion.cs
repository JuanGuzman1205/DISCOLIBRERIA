using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ProductosAplicacion : IProductosAplicacion
    {
        private IConexion conexion;
        public ProductosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Productos Insertar(Productos entidad)
        {
            this.conexion.Productos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Productos> Consultar()
        {
            return this.conexion.Productos!
                .ToList();
        }
        public Productos Actualizar(Productos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Productos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Productos Borrar(Productos entidad)
        {
            this.conexion.Productos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
