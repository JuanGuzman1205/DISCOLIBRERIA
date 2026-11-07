using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class EventosPresentacion : IEventosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EventosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Eventos> Insertar(Eventos entidad)
        {
            if (entidad.IdEvento != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Eventos>("Eventos/Insertar", entidad);
        }

        public async Task<Eventos> Actualizar(Eventos entidad)
        {
            if (entidad.IdEvento == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Eventos>("Eventos/Actualizar", entidad);
        }

        public async Task<Eventos> Borrar(Eventos entidad)
        {
            if (entidad.IdEvento == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Eventos>("Eventos/Borrar", entidad);
        }

        public async Task<List<Eventos>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Eventos>>("Eventos/Consultar", new Eventos());
        }

        public async Task<List<Eventos>> Buscar(Eventos entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Eventos>>("Eventos/Buscar", entidad);
        }

        private bool Validar(Eventos entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEncargado == 0 ||
                   string.IsNullOrEmpty(entidad.DetalleEvento) ||
                   entidad.FechaEvento == default(DateTime) ||
                   entidad.HoraFin <= entidad.HoraInicio;
        }
    }
}