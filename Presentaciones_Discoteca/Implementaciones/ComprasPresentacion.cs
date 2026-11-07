using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class ComprasPresentacion : IComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Compras> Insertar(Compras entidad)
        {
            if (entidad.IdCompra != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Compras>("Compras/Insertar", entidad);
        }

        public async Task<Compras> Actualizar(Compras entidad)
        {
            if (entidad.IdCompra == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Compras>("Compras/Actualizar", entidad);
        }

        public async Task<Compras> Borrar(Compras entidad)
        {
            if (entidad.IdCompra == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Compras>("Compras/Borrar", entidad);
        }

        public async Task<List<Compras>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Compras>>("Compras/Consultar", new Compras());
        }

        public async Task<List<Compras>> Buscar(Compras entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Compras>>("Compras/Buscar", entidad);
        }

        private bool Validar(Compras entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleado == 0 ||
                   entidad.Total < 0 ||
                   entidad.Fecha == default(DateTime);
        }
    }
}