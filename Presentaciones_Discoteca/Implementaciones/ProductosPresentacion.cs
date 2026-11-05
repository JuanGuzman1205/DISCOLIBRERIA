using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ProductosPresentacion : IProductosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.IdProducto == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.IdProducto == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Productos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.IdProducto != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Productos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.NomProducto) ||
                   string.IsNullOrEmpty(entidad.Presentacion) ||
                   entidad.PrecioCompra == 0 ||
                   entidad.PrecioVenta <= 0 ||
                   entidad.IdProveedor == 0 ||
                   entidad.IdCategoria == 0 ||
                   entidad.IdInventario == 0;
        }
    }
}
