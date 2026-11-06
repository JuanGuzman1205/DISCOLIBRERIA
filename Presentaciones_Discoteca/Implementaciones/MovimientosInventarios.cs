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

        public MovimientoInventarios Insertar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public MovimientoInventarios Actualizar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public MovimientoInventarios Borrar(MovimientoInventarios entidad)
        {
            if (entidad.IdMovimiento == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<MovimientoInventarios>("MovimientoInventarios/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<MovimientoInventarios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<MovimientoInventarios>>("MovimientoInventarios/Consultar", new MovimientoInventarios());
            task.Wait();
            return task.Result;
        }

        public List<MovimientoInventarios> Buscar(MovimientoInventarios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<MovimientoInventarios>>("MovimientoInventarios/Buscar", entidad);
            task.Wait();
            return task.Result;
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