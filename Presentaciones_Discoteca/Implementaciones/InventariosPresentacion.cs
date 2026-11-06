using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class InventariosPresentacion : IInventariosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public InventariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Inventarios Insertar(Inventarios entidad)
        {
            if (entidad.IdInventario != 0)
                throw new Exception("Ya se guardó");

            var task = this.IComunicaciones.Ejecutar<Inventarios>("Inventarios/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios Actualizar(Inventarios entidad)
        {
            if (entidad.IdInventario == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Inventarios>("Inventarios/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios Borrar(Inventarios entidad)
        {
            if (entidad.IdInventario == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Inventarios>("Inventarios/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Inventarios>>("Inventarios/Consultar", new Inventarios());
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> Buscar(Inventarios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Inventarios>>("Inventarios/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        // Inventarios no tiene método Validar porque la entidad solo tiene su llave
        // primaria (IdInventario), que genera la base de datos, y listas de navegación
        // (_ElementoInternos, _Productos, _MovimientoInventarios) que se llenan desde
        // las otras entidades. No hay ningún dato obligatorio que el usuario deba
        // diligenciar, así que no hay nada que validar antes de enviar a la API.
    }
}