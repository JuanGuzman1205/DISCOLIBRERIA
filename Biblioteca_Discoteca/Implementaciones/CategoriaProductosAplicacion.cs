using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class CategoriaProductosAplicacion : ICategoriaProductosAplicacion
    {
        private IConexion conexion;
        public CategoriaProductosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public CategoriaProductos Insertar(CategoriaProductos entidad)
        {
            this.conexion.CategoriaProductos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<CategoriaProductos> Consultar()
        {
            return this.conexion.CategoriaProductos!
                .ToList();
        }
        public CategoriaProductos Actualizar(CategoriaProductos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<CategoriaProductos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public CategoriaProductos Borrar(CategoriaProductos entidad)
        {
            this.conexion.CategoriaProductos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
