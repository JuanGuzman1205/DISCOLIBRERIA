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

        public async Task<DetalleReparaciones> Insertar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Insertar", entidad);
        }

        public async Task<DetalleReparaciones> Actualizar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Actualizar", entidad);
        }

        public async Task<DetalleReparaciones> Borrar(DetalleReparaciones entidad)
        {
            if (entidad.IdDetalleReparacion == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<DetalleReparaciones>("DetalleReparaciones/Borrar", entidad);
        }

        public async Task<List<DetalleReparaciones>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleReparaciones>>("DetalleReparaciones/Consultar", new DetalleReparaciones());
        }

        public async Task<List<DetalleReparaciones>> Buscar(DetalleReparaciones entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<DetalleReparaciones>>("DetalleReparaciones/Buscar", entidad);
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