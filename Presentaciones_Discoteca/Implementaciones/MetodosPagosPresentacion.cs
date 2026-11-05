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

        public MetodosPagos Insertar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos Actualizar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public MetodosPagos Borrar(MetodosPagos entidad)
        {
            if (entidad.IdMetodoPago == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<MetodosPagos>("MetodosPagos/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<MetodosPagos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<MetodosPagos>>("MetodosPagos/Consultar", new MetodosPagos());
            task.Wait();
            return task.Result;
        }

        public List<MetodosPagos> Buscar(MetodosPagos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<MetodosPagos>>("MetodosPagos/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(MetodosPagos entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.TipoMetodoPago);
        }
    }
}