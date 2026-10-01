using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ComprasAplicacion : IComprasAplicacion
    {
        private IConexion conexion;
        public ComprasAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Compras Insertar(Compras entidad)
        {
            this.conexion.Compras!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Compras> Consultar()
        {
            return this.conexion.Compras!
                .ToList();
        }
        public Compras Actualizar(Compras entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Compras>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Compras Borrar(Compras entidad)
        {
            this.conexion.Compras!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
