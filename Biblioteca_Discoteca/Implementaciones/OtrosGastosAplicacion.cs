using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class OtrosGastosAplicacion : IOtrosGastosAplicacion
    {
        private IConexion conexion;
        public OtrosGastosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public OtrosGastos Insertar(OtrosGastos entidad)
        {
            this.conexion.OtrosGastos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<OtrosGastos> Consultar()
        {
            return this.conexion.OtrosGastos!
                .ToList();
        }
        public OtrosGastos Actualizar(OtrosGastos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<OtrosGastos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public OtrosGastos Borrar(OtrosGastos entidad)
        {
            this.conexion.OtrosGastos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
