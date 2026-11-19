using Biblioteca_Discoteca.Entidades;
using Inventario_Discoteca.Entidades;
using Presentaciones_Discoteca.Interfaces;

namespace Presentaciones_Discoteca.Implementaciones
{
    public class UsuariosPresentacion : IUsuariosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public UsuariosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public async Task<Usuarios> Insertar(Usuarios entidad)
        {
            if (entidad.IdUsuario != 0)
                throw new Exception("Ya se guardó");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Usuarios>("Usuarios/Insertar", entidad);
        }

        public async Task<Usuarios> Actualizar(Usuarios entidad)
        {
            if (entidad.IdUsuario == 0)
                throw new Exception("No se ha guardado");

            if (Validar(entidad))
                throw new Exception("Falta información");

            return await this.IComunicaciones.Ejecutar<Usuarios>("Usuarios/Actualizar", entidad);
        }

        public async Task<Usuarios> Borrar(Usuarios entidad)
        {
            if (entidad.IdUsuario == 0)
                throw new Exception("No se ha guardado");

            return await this.IComunicaciones.Ejecutar<Usuarios>("Usuarios/Borrar", entidad);
        }

        public async Task<List<Usuarios>> Consultar()
        {
            return await this.IComunicaciones.Ejecutar<List<Usuarios>>("Usuarios/Consultar", new Usuarios());
        }

        public async Task<List<Usuarios>> Buscar(Usuarios entidad)
        {
            return await this.IComunicaciones.Ejecutar<List<Usuarios>>("Usuarios/Buscar", entidad);
        }

        private bool Validar(Usuarios entidad)
        {
            // Retorna true si falta la información requerida
            return entidad.IdEmpleado == 0 ||
                   entidad.FechaCreacion == default;
        }
    }
}