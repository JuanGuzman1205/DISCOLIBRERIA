using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class CategoriaProductosPresentacion : IEmpleadosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public CategoriaProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public CategoriaProductos Actualizar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public CategoriaProductos Borrar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<CategoriaProductos> Buscar(CategoriaProductos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<CategoriaProductos>>(
                "CategoriaProductos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<CategoriaProductos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<CategoriaProductos>>(
                "CategoriaProductos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public CategoriaProductos Insertar(CategoriaProductos entidad)
        {
            if (entidad.IdCategoria != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<CategoriaProductos>(
                "CategoriaProductos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(CategoriaProductos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.NomCategoria);
        }
    }
}
