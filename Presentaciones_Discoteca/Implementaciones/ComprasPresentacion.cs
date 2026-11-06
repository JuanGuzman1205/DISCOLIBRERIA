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

        public Compras Insertar(Compras entidad)
        {
            if (entidad.IdCompra != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Compras>("Compras/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Compras Actualizar(Compras entidad)
        {
            if (entidad.IdCompra == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Compras>("Compras/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Compras Borrar(Compras entidad)
        {
            if (entidad.IdCompra == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Compras>("Compras/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Compras> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>("Compras/Consultar", new Compras());
            task.Wait();
            return task.Result;
        }

        public List<Compras> Buscar(Compras entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Compras>>("Compras/Buscar", entidad);
            task.Wait();
            return task.Result;
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