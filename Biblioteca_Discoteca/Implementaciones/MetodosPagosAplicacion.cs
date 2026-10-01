using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class MetodosPagosAplicacion : IMetodosPagoAplicacion
    {
        private IConexion conexion;
        public MetodosPagosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public MetodosPagos Insertar(MetodosPagos entidad)
        {
            this.conexion.MetodosPagos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<MetodosPagos> Consultar()
        {
            return this.conexion.MetodosPagos!
                .ToList();
        }
        public MetodosPagos Actualizar(MetodosPagos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<MetodosPagos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            this.conexion.MetodosPagos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
