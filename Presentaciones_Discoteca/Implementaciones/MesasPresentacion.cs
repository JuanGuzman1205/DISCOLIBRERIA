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

        public Mesas Insertar(Mesas entidad)
        {
            if (entidad.IdMesa != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Mesas>("Mesas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Mesas Actualizar(Mesas entidad)
        {
            if (entidad.IdMesa == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Mesas>("Mesas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Mesas Borrar(Mesas entidad)
        {
            if (entidad.IdMesa == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Mesas>("Mesas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Mesas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Mesas>>("Mesas/Consultar", new Mesas());
            task.Wait();
            return task.Result;
        }

        public List<Mesas> Buscar(Mesas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Mesas>>("Mesas/Buscar", entidad);
            task.Wait();
            return task.Result;
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