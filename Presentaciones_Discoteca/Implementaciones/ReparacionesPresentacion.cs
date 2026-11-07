using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ReparacionesPresentacion : IReparacionesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ReparacionesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Reparaciones> Insertar(Reparaciones entidad)
        {
            if (entidad.IdReparacion != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Insertar", entidad);
        }

        public async Task<Reparaciones> Actualizar(Reparaciones entidad)
        {
            if (entidad.IdReparacion == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Actualizar", entidad);
        }

        public async Task<Reparaciones> Borrar(Reparaciones entidad)
        {
            if (entidad.IdReparacion == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Reparaciones>("Reparaciones/Borrar", entidad);
        }

        public async Task<List<Reparaciones>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Reparaciones>>("Reparaciones/Consultar", new Reparaciones());
        }

        public async Task<List<Reparaciones>> Buscar(Reparaciones entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Reparaciones>>("Reparaciones/Buscar", entidad);
        }

        private bool Validar(Reparaciones entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdSolicitante == 0 ||
                   entidad.IdEncargado == 0 ||
                   entidad.FechaReparacion == default(DateTime);
        }
    }
}