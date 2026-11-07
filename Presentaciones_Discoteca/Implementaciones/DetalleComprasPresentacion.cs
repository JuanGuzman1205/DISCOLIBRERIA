using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class DetalleComprasPresentacion : IDetalleComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetalleComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<DetalleCompras> Insertar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Insertar", entidad);
        }

        public async Task<DetalleCompras> Actualizar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Actualizar", entidad);
        }

        public async Task<DetalleCompras> Borrar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Borrar", entidad);
        }

        public async Task<List<DetalleCompras>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleCompras>>("DetalleCompras/Consultar", new DetalleCompras());
        }

        public async Task<List<DetalleCompras>> Buscar(DetalleCompras entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleCompras>>("DetalleCompras/Buscar", entidad);
        }

        private bool Validar(DetalleCompras entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdCompra == 0 ||
                   entidad.IdProducto == 0 ||
                   entidad.Cantidad <= 0 ||
                   entidad.Total <= 0;
        }
    }
}