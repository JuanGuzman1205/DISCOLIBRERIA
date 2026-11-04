using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ProveedoresPresentacion : IProveedoresPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ProveedoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            if (entidad.IdProveedor == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.IdProveedor == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Proveedores> Buscar(Proveedores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Proveedores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            if (entidad.IdProveedor != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
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
