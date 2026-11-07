using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class VentasPresentacion : IVentasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public VentasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Ventas> Insertar(Ventas entidad)
        {
            if (entidad.IdVenta != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Ventas>("Ventas/Insertar", entidad);
        }

        public async Task<Ventas> Actualizar(Ventas entidad)
        {
            if (entidad.IdVenta == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Ventas>("Ventas/Actualizar", entidad);
        }

        public async Task<Ventas> Borrar(Ventas entidad)
        {
            if (entidad.IdVenta == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Ventas>("Ventas/Borrar", entidad);
        }

        public async Task<List<Ventas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Ventas>>("Ventas/Consultar", new Ventas());
        }

        public async Task<List<Ventas>> Buscar(Ventas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Ventas>>("Ventas/Buscar", entidad);
        }

        private bool Validar(Ventas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleado == 0;
        }
    }
}