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

        public Facturas Insertar(Facturas entidad)
        {
            if (entidad.IdFactura != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Facturas>("Facturas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            if (entidad.IdFactura == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Facturas>("Facturas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Facturas Borrar(Facturas entidad)
        {
            if (entidad.IdFactura == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Facturas>("Facturas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Facturas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Facturas>>("Facturas/Consultar", new Facturas());
            task.Wait();
            return task.Result;
        }

        public List<Facturas> Buscar(Facturas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Facturas>>("Facturas/Buscar", entidad);
            task.Wait();
            return task.Result;
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