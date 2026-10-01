using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ClientesAplicacion : IClientesAplicacion
    {
        private IConexion conexion;
        public ClientesAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Clientes Insertar(Clientes entidad)
        {
            this.conexion.Clientes!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Clientes> Consultar()
        {
            return this.conexion.Clientes!
                .ToList();
        }
        public Clientes Actualizar(Clientes entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Clientes>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Clientes Borrar(Clientes entidad)
        {
            this.conexion.Clientes!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
