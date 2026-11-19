using Biblioteca_Discoteca.Entidades;
using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion conexion;
        public UsuariosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Usuarios Insertar(Usuarios entidad)
        {
            this.conexion.Usuarios!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Usuarios> Consultar()
        {
            return this.conexion.Usuarios!
                .ToList();
        }
        public Usuarios Actualizar(Usuarios entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Usuarios Borrar(Usuarios entidad)
        {
            this.conexion.Usuarios!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
