using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class OtrosGastosPresentacion : IOtrosGastosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public OtrosGastosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<OtrosGastos> Insertar(OtrosGastos entidad)
        {
            if (entidad.IdGasto != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Insertar", entidad);
        }

        public async Task<OtrosGastos> Actualizar(OtrosGastos entidad)
        {
            if (entidad.IdGasto == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Actualizar", entidad);
        }

        public async Task<OtrosGastos> Borrar(OtrosGastos entidad)
        {
            if (entidad.IdGasto == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Borrar", entidad);
        }

        public async Task<List<OtrosGastos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<OtrosGastos>>("OtrosGastos/Consultar", new OtrosGastos());
        }

        public async Task<List<OtrosGastos>> Buscar(OtrosGastos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<OtrosGastos>>("OtrosGastos/Buscar", entidad);
        }

        private bool Validar(OtrosGastos entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleado == 0 ||
                   string.IsNullOrEmpty(entidad.Descripcion) ||
                   entidad.Monto <= 0 ||
                   entidad.FechaGasto == default(DateTime);
        }
    }
}