using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class MesasPresentacion : IMesasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MesasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Mesas> Insertar(Mesas entidad)
        {
            if (entidad.IdMesa != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Mesas>("Mesas/Insertar", entidad);
        }

        public async Task<Mesas> Actualizar(Mesas entidad)
        {
            if (entidad.IdMesa == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Mesas>("Mesas/Actualizar", entidad);
        }

        public async Task<Mesas> Borrar(Mesas entidad)
        {
            if (entidad.IdMesa == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Mesas>("Mesas/Borrar", entidad);
        }

        public async Task<List<Mesas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Mesas>>("Mesas/Consultar", new Mesas());
        }

        public async Task<List<Mesas>> Buscar(Mesas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Mesas>>("Mesas/Buscar", entidad);
        }

        private bool Validar(Mesas entidad)
        {
            // Retorna true si falta la información requerida
            return string.IsNullOrEmpty(entidad.Ubicacion) ||
                   entidad.ConsumoMinimo <= 0 ||
                   entidad.Capacidad <= 0;

        }
    }
}