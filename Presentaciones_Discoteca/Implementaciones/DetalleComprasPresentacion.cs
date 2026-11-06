using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class DetalleComprasPresentacion : IDetalleComprasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public DetalleComprasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public DetalleCompras Insertar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleCompras Actualizar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public DetalleCompras Borrar(DetalleCompras entidad)
        {
            if (entidad.IdDetalleCompra == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<DetalleCompras>("DetalleCompras/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetalleCompras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleCompras>>("DetalleCompras/Consultar", new DetalleCompras());
            task.Wait();
            return task.Result;
        }

        public List<DetalleCompras> Buscar(DetalleCompras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<DetalleCompras>>("DetalleCompras/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(DetalleCompras entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdCompra == 0 ||
                   entidad.IdProducto == 0 ||
                   entidad.Cantidad <= 0 ||
                   entidad.Total <= 0;
        }
    }
}