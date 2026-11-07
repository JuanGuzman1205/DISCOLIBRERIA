using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class CajasPresentacion : ICajasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CajasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Cajas> Insertar(Cajas entidad)
        {
            if (entidad.IdCaja != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Cajas>("Cajas/Insertar", entidad);
        }

        public async Task<Cajas> Actualizar(Cajas entidad)
        {
            if (entidad.IdCaja == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Cajas>("Cajas/Actualizar", entidad);
        }

        public async Task<Cajas> Borrar(Cajas entidad)
        {
            if (entidad.IdCaja == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Cajas>("Cajas/Borrar", entidad);
        }

        public async Task<List<Cajas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Cajas>>("Cajas/Consultar", new Cajas());
        }

        public async Task<List<Cajas>> Buscar(Cajas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Cajas>>("Cajas/Buscar", entidad);
        }

        private bool Validar(Cajas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleadoCaja == 0 ||
                   entidad.DineroInicial < 0;
        }
    }
}