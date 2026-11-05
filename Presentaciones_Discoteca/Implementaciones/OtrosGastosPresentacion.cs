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

        public OtrosGastos Insertar(OtrosGastos entidad)
        {
            if (entidad.IdGasto != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public OtrosGastos Actualizar(OtrosGastos entidad)
        {
            if (entidad.IdGasto == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public OtrosGastos Borrar(OtrosGastos entidad)
        {
            if (entidad.IdGasto == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<OtrosGastos>("OtrosGastos/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<OtrosGastos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<OtrosGastos>>("OtrosGastos/Consultar", new OtrosGastos());
            task.Wait();
            return task.Result;
        }

        public List<OtrosGastos> Buscar(OtrosGastos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<OtrosGastos>>("OtrosGastos/Buscar", entidad);
            task.Wait();
            return task.Result;
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