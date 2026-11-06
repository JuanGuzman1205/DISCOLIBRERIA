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

        public Ventas Insertar(Ventas entidad)
        {
            if (entidad.IdVenta != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Ventas>("Ventas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Ventas Actualizar(Ventas entidad)
        {
            if (entidad.IdVenta == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Ventas>("Ventas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Ventas Borrar(Ventas entidad)
        {
            if (entidad.IdVenta == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Ventas>("Ventas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Ventas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Ventas>>("Ventas/Consultar", new Ventas());
            task.Wait();
            return task.Result;
        }

        public List<Ventas> Buscar(Ventas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Ventas>>("Ventas/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Ventas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleado == 0;
        }
    }
}