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

        public async Task<Reservas> Insertar(Reservas entidad)
        {
            if (entidad.IdReserva != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Reservas>("Reservas/Insertar", entidad);
        }

        public async Task<Reservas> Actualizar(Reservas entidad)
        {
            if (entidad.IdReserva == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Reservas>("Reservas/Actualizar", entidad);
        }

        public async Task<Reservas> Borrar(Reservas entidad)
        {
            if (entidad.IdReserva == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Reservas>("Reservas/Borrar", entidad);
        }

        public async Task<List<Reservas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Reservas>>("Reservas/Consultar", new Reservas());
        }

        public async Task<List<Reservas>> Buscar(Reservas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Reservas>>("Reservas/Buscar", entidad);
        }

        private bool Validar(Reservas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdCliente == 0 ||
                   entidad.FechaReserva == default(DateTime);
        }
    }
}