using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class CategoriaProductosPresentacion : ICategoriaProductosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public CategoriaProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<CategoriaProductos> Actualizar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Actualizar",
                entidad);
        }

        public async Task<CategoriaProductos> Borrar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Borrar",
                entidad);
        }

        public async Task<List<CategoriaProductos>> Buscar(CategoriaProductos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<CategoriaProductos>>(
                "CategoriaProductos/Buscar",
                entidad);
        }

        public async Task<List<CategoriaProductos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<CategoriaProductos>>(
                "CategoriaProductos/Consultar",
                null);
        }

        public async Task<CategoriaProductos> Insertar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Insertar",
                entidad);
        }

        private bool Validar(CategoriaProductos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.NomCategoria);
        }
    }
}
