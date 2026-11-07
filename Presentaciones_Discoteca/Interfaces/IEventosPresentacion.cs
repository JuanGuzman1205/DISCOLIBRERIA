using Inventario_Discoteca.Entidades;

namespace Presentaciones_Discoteca.Interfaces
{
    public interface IEventosPresentacion
    {
        Task<Eventos> Insertar(Eventos entidad);
        Task<Eventos> Actualizar(Eventos entidad);
        Task<List<Eventos>> Consultar();
        Task<List<Eventos>> Buscar(Eventos entidad);
        Task<Eventos> Borrar(Eventos entidad);
    }
}