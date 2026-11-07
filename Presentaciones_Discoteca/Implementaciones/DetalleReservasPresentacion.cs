using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class DetalleReservasPresentacion : IDetalleReservasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetalleReservasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<DetalleReservas> Insertar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Insertar", entidad);
        }

        public async Task<DetalleReservas> Actualizar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Actualizar", entidad);
        }

        public async Task<DetalleReservas> Borrar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Borrar", entidad);
        }

        public async Task<List<DetalleReservas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleReservas>>("DetalleReservas/Consultar", new DetalleReservas());
        }

        public async Task<List<DetalleReservas>> Buscar(DetalleReservas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleReservas>>("DetalleReservas/Buscar", entidad);
        }

        private bool Validar(DetalleReservas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdReserva == 0 ||
                   entidad.IdMesa == 0;
        }
    }
}