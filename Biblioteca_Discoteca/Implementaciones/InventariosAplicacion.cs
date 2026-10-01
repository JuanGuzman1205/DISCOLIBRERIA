using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class InventariosAplicacion :IInventariosAplicacion
    {
        private IConexion conexion;
        public InventariosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Inventarios Insertar(Inventarios entidad)
        {
            this.conexion.Inventarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Inventarios> Consultar()
        {
            return this.conexion.Inventarios!
                .ToList();
        }
        public Inventarios Actualizar(Inventarios entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Inventarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Inventarios Borrar(Inventarios entidad)
        {
            this.conexion.Inventarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
