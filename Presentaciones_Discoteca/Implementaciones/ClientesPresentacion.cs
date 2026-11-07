using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ClientesPresentacion : IClientesPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public ClientesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Clientes> Actualizar(Clientes entidad)
        {
            if (entidad.IdCliente == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Actualizar",
                entidad);
        }

        public async Task<Clientes> Borrar(Clientes entidad)
        {
            if (entidad.IdCliente == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Borrar",
                entidad);
        }

        public async Task<List<Clientes>> Buscar(Clientes entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Buscar",
                entidad);
        }

        public async Task<List<Clientes>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Consultar",
                new Clientes());
        }

        public async Task<Clientes> Insertar(Clientes entidad)
        {
            if (entidad.IdCliente != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Clientes>(
                "Clientes/Insertar",
                entidad);
        }

        private bool Validar(Clientes entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Apellido);
        }
    }
}
