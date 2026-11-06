using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ReparacionesPresentacion : IReparacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ReparacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Reparaciones Insertar(Reparaciones entidad)
        {
            if (entidad.IdReparacion != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Reparaciones Actualizar(Reparaciones entidad)
        {
            if (entidad.IdReparacion == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Reparaciones Borrar(Reparaciones entidad)
        {
            if (entidad.IdReparacion == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reparaciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Reparaciones>>("Reparaciones/Consultar", new Reparaciones());
            task.Wait();
            return task.Result;
        }

        public List<Reparaciones> Buscar(Reparaciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Reparaciones>>("Reparaciones/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Reparaciones entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdSolicitante == 0 ||
                   entidad.IdEncargado == 0 ||
                   entidad.FechaReparacion == default(DateTime);
        }
    }
}