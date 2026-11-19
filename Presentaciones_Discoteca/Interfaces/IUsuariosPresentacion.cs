using Biblioteca_Discoteca.Entidades;
using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IUsuariosPresentacion
    {
        Task<Usuarios> Insertar(Usuarios entidad);
        Task<Usuarios> Actualizar(Usuarios entidad);
        Task<List<Usuarios>> Consultar();
        Task<List<Usuarios>> Buscar(Usuarios entidad);
        Task<Usuarios> Borrar(Usuarios entidad);
    }
}