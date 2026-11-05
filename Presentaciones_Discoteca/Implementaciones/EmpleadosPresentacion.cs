using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class EmpleadosPresentacion : IEmpleadosPresentacion
    {
        private  IComunicaciones IComunicaciones;

        public EmpleadosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            if (entidad.IdEmpleado == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Empleados Borrar(Empleados entidad)
        {
            if (entidad.IdEmpleado == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> Buscar(Empleados entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Consultar",
                new Empleados);
            task.Wait();
            return task.Result;
        }

        public Empleados Insertar(Empleados entidad)
        {
            if (entidad.IdEmpleado != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Empleados>(
                "Empleados/Insertar",
                entidad);
            task.Wait();
            return task.Result;
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
