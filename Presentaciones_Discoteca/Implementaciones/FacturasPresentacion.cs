using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class FacturasPresentacion : IFacturasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public FacturasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Facturas> Insertar(Facturas entidad)
        {
            if (entidad.IdFactura != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Facturas>("Facturas/Insertar", entidad);
        }

        public async Task<Facturas> Actualizar(Facturas entidad)
        {
            if (entidad.IdFactura == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Facturas>("Facturas/Actualizar", entidad);
        }

        public async Task<Facturas> Borrar(Facturas entidad)
        {
            if (entidad.IdFactura == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Facturas>("Facturas/Borrar", entidad);
        }

        public async Task<List<Facturas>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Facturas>>("Facturas/Consultar", new Facturas());
        }

        public async Task<List<Facturas>> Buscar(Facturas entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Facturas>>("Facturas/Buscar", entidad);
        }

        private bool Validar(Facturas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdVenta == 0 ||
                   entidad.IdMesero == 0 ||
                   entidad.IdBarra == 0 ||
                   entidad.IdCaja == 0 ||
                   entidad.IdMetodoPago == 0 ||
                   entidad.FechaFacturacion == default(DateTime);
        }
    }
}