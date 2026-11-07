using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ProveedoresPresentacion : IProveedoresPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ProveedoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Proveedores> Actualizar(Proveedores entidad)
        {
            if (entidad.IdProveedor == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Actualizar",
                entidad);
        }

        public async Task<Proveedores> Borrar(Proveedores entidad)
        {
            if (entidad.IdProveedor == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Borrar",
                entidad);
        }

        public async Task<List<Proveedores>> Buscar(Proveedores entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Buscar",
                entidad);
        }

        public async Task<List<Proveedores>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Consultar",
                null);
        }

        public async Task<Proveedores> Insertar(Proveedores entidad)
        {
            if (entidad.IdProveedor != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Insertar",
                entidad);
        }

        private bool Validar(Proveedores entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Telefono) ||
                   string.IsNullOrEmpty(entidad.Email);
        }
    }
}
