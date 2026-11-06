using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ClientesPresentacion : IClientesPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ClientesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            if (entidad.IdCliente == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes Borrar(Clientes entidad)
        {
            if (entidad.IdCliente == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> Buscar(Clientes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Consultar",
                new Clientes());
            task.Wait();
            return task.Result;
        }

        public Clientes Insertar(Clientes entidad)
        {
            if (entidad.IdCliente != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Clientes entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Apellido);
        }
    }
}
