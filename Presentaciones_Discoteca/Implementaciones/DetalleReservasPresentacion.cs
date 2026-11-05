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

        public DetalleReservas Insertar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleReservas Actualizar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleReservas Borrar(DetalleReservas entidad)
        {
            if (entidad.IdDetalleReserva == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetalleReservas>("DetalleReservas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetalleReservas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleReservas>>("DetalleReservas/Consultar", new DetalleReservas());
            task.Wait();
            return task.Result;
        }

        public List<DetalleReservas> Buscar(DetalleReservas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleReservas>>("DetalleReservas/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetalleReservas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdReserva == 0 ||
                   entidad.IdMesa == 0;
        }
    }
}