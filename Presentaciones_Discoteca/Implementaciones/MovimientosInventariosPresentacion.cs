using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class MovimientoInventariosPresentacion : IMovimientoInventariosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MovimientoInventariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<MovimientoInventarios> Insertar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Insertar", entidad);
        }

        public async Task<MovimientoInventarios> Actualizar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Actualizar", entidad);
        }

        public async Task<MovimientoInventarios> Borrar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Borrar", entidad);
        }

        public async Task<List<MovimientoInventarios>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<MovimientoInventarios>>("MovimientoInventarios/Consultar", new MovimientoInventarios());
        }

        public async Task<List<MovimientoInventarios>> Buscar(MovimientoInventarios entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<MovimientoInventarios>>("MovimientoInventarios/Buscar", entidad);
        }

        private bool Validar(MovimientoInventarios entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdMovimiento == 0 ||
                   entidad.Cantidad <= 0 ||
                   string.IsNullOrEmpty(entidad.TipoMovimiento) ||
                   entidad.FechaMovimiento == default(DateTime);
        }
    }
}