using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ReservasPresentacion : IReservasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ReservasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Reservas Insertar(Reservas entidad)
        {
            if (entidad.IdReserva != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Reservas>("Reservas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Reservas Actualizar(Reservas entidad)
        {
            if (entidad.IdReserva == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Reservas>("Reservas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Reservas Borrar(Reservas entidad)
        {
            if (entidad.IdReserva == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Reservas>("Reservas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reservas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Reservas>>("Reservas/Consultar", new Reservas());
            task.Wait();
            return task.Result;
        }

        public List<Reservas> Buscar(Reservas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Reservas>>("Reservas/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Reservas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdCliente == 0 ||
                   entidad.FechaReserva == default(DateTime);
        }
    }
}