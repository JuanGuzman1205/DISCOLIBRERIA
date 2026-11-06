using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class DetalleVentasPresentacion : IDetalleVentasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetalleVentasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetalleVentas Insertar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleVentas Actualizar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleVentas Borrar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetalleVentas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleVentas>>("DetalleVentas/Consultar", new DetalleVentas());
            task.Wait();
            return task.Result;
        }

        public List<DetalleVentas> Buscar(DetalleVentas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleVentas>>("DetalleVentas/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetalleVentas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdVenta == 0 ||
                   entidad.IdProducto == 0 ||
                   entidad.Cantidad <= 0 ||
                   entidad.PrecioUnitario <= 0;
        }
    }
}