using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class MetodosPagosPresentacion : IMetodosPagosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MetodosPagosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<MetodosPagos> Insertar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Insertar", entidad);
        }

        public async Task<MetodosPagos> Actualizar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Actualizar", entidad);
        }

        public async Task<MetodosPagos> Borrar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Borrar", entidad);
        }

        public async Task<List<MetodosPagos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<MetodosPagos>>("MetodosPagos/Consultar", new MetodosPagos());
        }

        public async Task<List<MetodosPagos>> Buscar(MetodosPagos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<MetodosPagos>>("MetodosPagos/Buscar", entidad);
        }

        private bool Validar(MetodosPagos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.TipoMetodoPago);
        }
    }
}