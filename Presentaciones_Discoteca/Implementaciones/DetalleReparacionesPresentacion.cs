using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class DetalleReparacionesPresentacion : IDetalleReparacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetalleReparacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetalleReparaciones Insertar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleReparaciones Actualizar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleReparaciones Borrar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetalleReparaciones> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleReparaciones>>("DetalleReparaciones/Consultar", new DetalleReparaciones());
            task.Wait();
            return task.Result;
        }

        public List<DetalleReparaciones> Buscar(DetalleReparaciones entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleReparaciones>>("DetalleReparaciones/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetalleReparaciones entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdReparacion == 0 ||
                   entidad.IdElementoInterno == 0 ||
                   string.IsNullOrEmpty(entidad.DescripcionReparacion) ||
                   entidad.CostoReparacion <= 0;
        }
    }
}