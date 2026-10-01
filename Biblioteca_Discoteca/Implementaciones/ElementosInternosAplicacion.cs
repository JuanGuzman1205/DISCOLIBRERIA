using Biblioteca_Discoteca.Interfaces;
using Inventario_Discoteca.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca_Discoteca.Implementaciones
{
    public class ElementosInternosAplicacion :IElementosInternosAplicacion
    {
        private IConexion conexion;
        public ElementosInternosAplicacion(IConexion conexion)
        {
            this.conexion = conexion;
        }
        public ElementosInternos Insertar(ElementosInternos entidad)
        {
            this.conexion.ElementosInternos!.Add(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
        public List<ElementosInternos> Consultar()
        {
            return this.conexion.ElementosInternos!
                .ToList();
        }
        public ElementosInternos Actualizar(ElementosInternos entidad)
        {
            //Claculos o operaciones
            var entry = this.conexion!.Entry<ElementosInternos>(entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
            return entidad;
        }
        public ElementosInternos Borrar(ElementosInternos entidad)
        {
            this.conexion.ElementosInternos!.Remove(entidad!);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}
