using Inventario_Discoteca.Entidades;
using Microsoft.IdentityModel.Tokens;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ElementosInternosPresentacion : IElementosInternosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ElementosInternosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public ElementosInternos Actualizar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public ElementosInternos Borrar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ElementosInternos> Buscar(ElementosInternos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<ElementosInternos>>(
                "ElementosInternos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ElementosInternos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<ElementosInternos>>(
                "ElementosInternos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public ElementosInternos Insertar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(ElementosInternos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.NombreElementoInterno) ||
                   entidad.CantidadElementoInterno <= 0 ||
                   entidad.PrecioElementoInterno <= 0 ||
                   entidad.IdInventario == 0;

        }
    }
}
