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

        public Cajas Insertar(Cajas entidad)
        {
            if (entidad.IdCaja != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Cajas>("Cajas/Insertar", entidad);
            task.Wait();
            return task.Result;
        }

        public Cajas Actualizar(Cajas entidad)
        {
            if (entidad.IdCaja == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            var task = this.IComunicaciones.Ejecutar<Cajas>("Cajas/Actualizar", entidad);
            task.Wait();
            return task.Result;
        }

        public Cajas Borrar(Cajas entidad)
        {
            if (entidad.IdCaja == 0)
                throw new Exception("No se ha guardado");

            var task = this.IComunicaciones.Ejecutar<Cajas>("Cajas/Borrar", entidad);
            task.Wait();
            return task.Result;
        }

        public List<Cajas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Cajas>>("Cajas/Consultar", new Cajas());
            task.Wait();
            return task.Result;
        }

        public List<Cajas> Buscar(Cajas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Cajas>>("Cajas/Buscar", entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Cajas entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleadoCaja == 0 ||
                   entidad.DineroInicial < 0;
        }
    }
}