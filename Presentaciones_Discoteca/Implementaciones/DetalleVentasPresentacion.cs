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

        public async Task<DetalleVentas> Insertar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Insertar", entidad);
        }

        public async Task<DetalleVentas> Actualizar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Actualizar", entidad);
        }

        public async Task<DetalleVentas> Borrar(DetalleVentas entidad)
        {
            if (entidad.IdDetalleVenta == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<DetalleVentas>("DetalleVentas/Borrar", entidad);
        }

        public async Task<List<DetalleVentas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleVentas>>("DetalleVentas/Consultar", new DetalleVentas());
        }

        public async Task<List<DetalleVentas>> Buscar(DetalleVentas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleVentas>>("DetalleVentas/Buscar", entidad);
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