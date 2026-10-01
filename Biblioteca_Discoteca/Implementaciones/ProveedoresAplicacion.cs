using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ProveedoresAplicacion : IProveedoresAplicacion
    {
        private IConexion conexion;
        public ProveedoresAplicacion(IConexion conexion) {
            this.conexion = conexion;
        }
        public Proveedores Insertar(Proveedores entidad)
        {
            this.conexion.Proveedores!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Proveedores> Consultar() {
            return this.conexion.Proveedores!
                .ToList();
        }
        public Proveedores Actualizar(Proveedores entidad) {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Proveedores>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Proveedores Borrar(Proveedores entidad) {
            this.conexion.Proveedores!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}

