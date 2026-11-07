using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class EmpleadosPresentacion : IEmpleadosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public EmpleadosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Empleados> Actualizar(Empleados entidad)
        {
            if (entidad.IdEmpleado == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Actualizar",
                entidad);
        }

        public async Task<Empleados> Borrar(Empleados entidad)
        {
            if (entidad.IdEmpleado == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Borrar",
                entidad);
        }

        public async Task<List<Empleados>> Buscar(Empleados entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Buscar",
                entidad);
        }

        public async Task<List<Empleados>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Consultar",
                new Empleados());
        }

        public async Task<Empleados> Insertar(Empleados entidad)
        {
            if (entidad.IdEmpleado != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Insertar",
                entidad);
        }

        private bool Validar(Empleados entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.Nombre) ||
                   string.IsNullOrEmpty(entidad.Telefono) ||
                   string.IsNullOrEmpty(entidad.Cargo) ||
                   entidad.Nomina == 0;
        }
    }
}
