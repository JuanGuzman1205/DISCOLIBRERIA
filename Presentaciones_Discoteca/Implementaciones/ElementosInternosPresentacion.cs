using Inventario_Discoteca.Entidades;
using Microsoft.IdentityModel.Tokens;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ElementosInternosPresentacion : IElementosInternosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ElementosInternosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<ElementosInternos> Actualizar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Actualizar",
                entidad);
        }

        public async Task<ElementosInternos> Borrar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Borrar",
                entidad);
        }

        public async Task<List<ElementosInternos>> Buscar(ElementosInternos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<ElementosInternos>>(
                "ElementosInternos/Buscar",
                entidad);
        }

        public async Task<List<ElementosInternos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<ElementosInternos>>(
                "ElementosInternos/Consultar",
                null);
        }

        public async Task<ElementosInternos> Insertar(ElementosInternos entidad)
        {
            if (entidad.IdElementoInterno != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<ElementosInternos>(
                "ElementosInternos/Insertar",
                entidad);
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
