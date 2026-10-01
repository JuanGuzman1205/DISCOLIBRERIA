using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class EmpleadosAplicacion : IEmpleadosAplicacion
    {
        private IConexion conexion;
        public EmpleadosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public Empleados Insertar(Empleados entidad)
        {
            this.conexion.Empleados!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<Empleados> Consultar()
        {
            return this.conexion.Empleados!
                .ToList();
        }
        public Empleados Actualizar(Empleados entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<Empleados>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public Empleados Borrar(Empleados entidad)
        {
            this.conexion.Empleados!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
