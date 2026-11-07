using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ProductosPresentacion : IProductosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Productos> Actualizar(Productos entidad)
        {
            if (entidad.IdProducto == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Actualizar",
                entidad);
        }

        public async Task<Productos> Borrar(Productos entidad)
        {
            if (entidad.IdProducto == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Borrar",
                entidad);
        }

        public async Task<List<Productos>> Buscar(Productos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Buscar",
                entidad);
        }

        public async Task<List<Productos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Consultar",
                null);
        }

        public async Task<Productos> Insertar(Productos entidad)
        {
            if (entidad.IdProducto != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Insertar",
                entidad);
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
